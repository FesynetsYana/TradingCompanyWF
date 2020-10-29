using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TopicWF
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtPassword.Text + "\n" + txtUsername.Text);
        }
    }
}
