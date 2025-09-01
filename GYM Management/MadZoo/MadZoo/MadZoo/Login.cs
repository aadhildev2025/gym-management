using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadZoo
{
    public partial class  Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_username.Text.Equals("") || txt_password.Text.Equals(""))
            {
                MessageBox.Show("Please fill the empy fields", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                string un = txt_username.Text;
                string pwd = txt_password.Text;
                if (un.Equals("Admin") && pwd.Equals("2005"))
                {
                    MessageBox.Show("Login Successfull", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    //Creating the object to open up the next page
                    Main_menu main_Menu = new Main_menu();
                    main_Menu.Show();
                }
                else 
                {
                    MessageBox.Show("Password or Username is incorrect", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you wanna exit?", "Exit message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                txt_password.UseSystemPasswordChar = true;
            }
            else
            {
                txt_password.UseSystemPasswordChar = false;
            }
        }
    }
}
