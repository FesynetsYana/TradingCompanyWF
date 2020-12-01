using System;
using DTO;
using BusinessLogic.Concrete;
using DAL.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TopicWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private UserManager userManager;
        private UserDal userDal;
        private string connectionString = "Data Source=localhost;Initial Catalog=ManagerNews;Integrated Security=True";
        public MainWindow()
        {   
            InitializeComponent();
            userDal = new UserDal(connectionString);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            uint isLogIn = 0;
            UserDTO user = new UserDTO();
            user.Login = txt_Login.Text;
            user.Password = txt_Password.Text;
            isLogIn = userDal.LogIn(user);

            if (isLogIn != 0)
            {
                if (isLogIn == 1)
                {
                    user.Email = connectionString;
                    userManager = new ClientManager(user);
                }
                else
                {
                    user.Email = connectionString;
                    userManager = new AdminManager(user);
                }
                TopicList tp = new TopicList(userManager);
                this.Visibility = Visibility.Hidden;
                tp.Show();

            }
        }

    }
}
