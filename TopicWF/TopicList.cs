using BusinessLogic.Concrete;
using DTO;
using DAL.Concrete;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TopicWF
{
    public partial class TopicList : Form
    {
        private UserManager userManager;

        public TopicList(UserManager user)
        {
            InitializeComponent();
            userManager = user;
            LoadData();
        }

   
        private void LoadData()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=ManagerNews;Integrated Security=True";

            SqlConnection myConnection = new SqlConnection(connectionString);

            myConnection.Open();

            string query = "SELECT * FROM Topics ORDER BY ID";
            SqlCommand command = new SqlCommand(query,myConnection);

            SqlDataReader reader = command.ExecuteReader();
            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
            }

            reader.Close();
            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

     
    }
}
