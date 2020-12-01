using System;
using DTO;
using TopicWPF.ViewModels;
using BusinessLogic.Concrete;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;
using System.Configuration;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.VisualBasic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Drawing;

namespace TopicWPF
{
    /// <summary>
    /// Interaction logic for TopicList.xaml
    /// </summary>
    public class Itm
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    }
    public partial class TopicList : Window
    {

        private UserManager userManager;

        public TopicList(UserManager user)
        {
            InitializeComponent();
            userManager = user;

            btnDelete.Visibility = btnAdd.Visibility = (userManager.addRemovePermitions ? Visibility.Visible : Visibility.Hidden);
            updateTable(userManager.GetAll());
        }
        private void updateTable(List<(long ID, string FullName, string Title, string Text)> ls)
        {
            dataGridView1.Items.Clear();
            foreach (var row in ls)
            {
                Itm it = new Itm();
                it.ID = row.ID;
                it.FullName = row.FullName;
                it.Title = row.Title;
                it.Text = row.Text;
                dataGridView1.Items.Add(it);
            }
        }

        private void btnAddTopic_Click(object sender, EventArgs e)
        {
            string input_title = Microsoft.VisualBasic.Interaction.InputBox("Input Title!", "Add", "Title");
            string input_text = Microsoft.VisualBasic.Interaction.InputBox("Input Text!", "Add", "Text");
            string input_comment = Microsoft.VisualBasic.Interaction.InputBox("Input Comment!", "Add", "Comment");

            if (!string.IsNullOrEmpty(input_title) &&
                !string.IsNullOrEmpty(input_title) &&
                !string.IsNullOrEmpty(input_title) &&
                userManager.AddTopic(input_title, input_text, input_comment))
            {
                updateTable(userManager.GetAll());
            }

        }

        private void ButtonFind_Click(object sender, EventArgs e)
        {
            string input_comment = Microsoft.VisualBasic.Interaction.InputBox("What do you want to find? Input Title!", "Find", "Smth from Title");
            if (!string.IsNullOrEmpty(input_comment))
            {
                updateTable(userManager.Find(input_comment));
            }

        }

        private void dataGridView1_MouseRightButtonDown(object sender, EventArgs e)
        {
            updateTable(userManager.GetAll());

        }
        private void btnDeleteTopic_Click(object sender, EventArgs e)
        {
            string input_id = Microsoft.VisualBasic.Interaction.InputBox("Input topic id!", "Delete", "ID");

            if (!string.IsNullOrEmpty(input_id))
            {
                try
                {
                    if (userManager.DeleteTopic(Convert.ToInt64(input_id)) >= 0)
                    {
                        updateTable(userManager.GetAll());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Incorrect input data!\n" + ex.Message.ToString(), "Error");
                }
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }

        private void dataGridView1_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
