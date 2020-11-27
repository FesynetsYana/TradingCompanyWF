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
        string connectionString;
        SqlDataAdapter adapter;
        DataTable topicTable; 

         private UserManager userManager;
        public TopicList(UserManager user)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["ManagerNews"].ConnectionString;

            dgTopics.RowEditEnding += TopicGrid_RowEditEnding;

            userManager = user;
            //btnDeleteTopic.Visible = btnAddTopic.Visible = userManager.addRemovePermitions;
            //updateTable(userManager.GetAll());
        }

        private void TopicGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            UpdateDB();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string sql = "SELECT * FROM Topics";
            topicTable = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                adapter.InsertCommand = new SqlCommand("sp_InsertTopic", connection);
                adapter.InsertCommand = new SqlCommand("sp_InsertUser", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 100, "FullName"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@title", SqlDbType.NVarChar, 100, "Title"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@text", SqlDbType.NVarChar, 100, "Text"));

                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(topicTable);

                dgTopics.ItemsSource = topicTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(topicTable);
        }
 

        private void _topicCollection_Filter(object sender, FilterEventArgs e)
        {
            var filter = txtSearch.Text;
            var topic = e.Item as TopicDTO;
            if (topic.Title.Contains(filter) || topic.Text.ToString().Contains(filter))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }


        private void btnDeleteTopic_Click(object sender, RoutedEventArgs e)
        {
            if (dgTopics.SelectedItems != null)
            {
                for (int i = 0; i < dgTopics.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = dgTopics.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 0; intCounter--)
                App.Current.Windows[intCounter].Close();
        }
        
        private void btnAddTopic_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgTopics.ItemsSource).Refresh();

        }

        private void dgTopics_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void dgTopics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnUpdateTopic_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }
    }
}
