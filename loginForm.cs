using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagement.Connection;

namespace StudentManagement
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
        

        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Logginbutton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(UsernametextBox.Text) && !string.IsNullOrEmpty(PasswordtextBox.Text))
            {
                string mySQL = string.Empty;

                mySQL += "SELECT * FROM LoginTbl ";
                mySQL += "WHERE Username = '"+ UsernametextBox.Text +"' ";
                mySQL += "AND Password = '"+PasswordtextBox.Text + "' ";

                DataTable userData = ServerConnection.executeSQL(mySQL);

                if(userData.Rows.Count > 0)
                {
                    UsernametextBox.Clear();
                    PasswordtextBox.Clear();

                    this.Hide();

                    mainForm formMain = new mainForm();
                    formMain.ShowDialog();
                    formMain = null; 

                    this.Show();
                    this.UsernametextBox.Select();
                }
                else
                {
                    MessageBox.Show("incorrect username and password");
                    UsernametextBox.Focus();
                    UsernametextBox.SelectAll();
                }

            }
            else
            {
                MessageBox.Show("please enter credential");
                UsernametextBox.Select();
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                PasswordtextBox.UseSystemPasswordChar = false;
            }
            else
            {
                PasswordtextBox.UseSystemPasswordChar = true;
            }
        }
    }
}
