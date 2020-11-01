using System;
using DTO;
using DAL.Concrete;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLogic.Concrete;

namespace TopicWF
{
    public partial class Login : Form
    {
        private UserManager userManager;
        private UserDal userDal;
        private string connectionString = "Data Source=localhost;Initial Catalog=ManagerNews;Integrated Security=True";
        public Login()
        {
            InitializeComponent();
            userDal = new UserDal(connectionString);
        }



        private void btnExit_Click_1(object sender, EventArgs e)
        {
            //this.Close();
            if (MessageBox.Show("Really Quit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                Application.Exit();

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            uint isLogIn = 0;
            UserDTO user = new UserDTO();
            user.Login = txtUsername.Text;
            user.Password = txtPassword.Text;
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
                this.Visible = false;
                tp.Show();
            }
        }
    }
}
