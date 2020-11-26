using System;
using BusinessLogic.Concrete;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for TopicList.xaml
    /// </summary>
    public partial class TopicList : Window
    {

        private UserManager userManager;
        public TopicList(UserManager user)
        {
            InitializeComponent();

            userManager = user;
            //btnDeleteTopic.Visible = btnAddTopic.Visible = userManager.addRemovePermitions;
            updateTable(userManager.GetAll());
        }

        private void updateTable(List<(long ID, string FullName, string Title, string Text)> ls)
        {
            //dataGridView1.Rows.Clear();
            //foreach (var row in ls)
            //{
            //    int rowNumber = dataGridView1.Rows.Add();
            //    dataGridView1.Rows[rowNumber].Cells["columnID"].Value = row.ID;
            //    dataGridView1.Rows[rowNumber].Cells["columnName"].Value = row.FullName;
            //    dataGridView1.Rows[rowNumber].Cells["columnTitle"].Value = row.Title;
            //    dataGridView1.Rows[rowNumber].Cells["columnText"].Value = row.Text;
            //}
        }

        private void btnDeleteTopic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddTopic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void dgTopics_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
