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

namespace MadZoo
{
    public partial class addpay : Form
    {
        public addpay()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data source = AADHIL\\SQLEXPRESS; initial catalog= MadZoo_GYM ; integrated security = true");


            string query = "SELECT * FROM MadZoo_GYM WHERE MEM_ID = @MEM_ID;";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MEM_ID", membID.Text);
            connection.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                {
                    if (dr.Read())
                    {
                        label16.Text = dr["MEM_ID"].ToString();
                        label17.Text = dr["MEM_Name"].ToString();
                        lblmembfee.Text = dr["MEMfee"].ToString();
                        lblmtchfee.Text = dr["matchFEE"].ToString();
                        lblcoach.Text = dr["CoachingFEE"].ToString();
                        lbltot.Text = dr["total_Payment"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("User not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                membID.Text = "";
                label16.Text = "-";
                lblmembfee.Text = "-";
                lblmtchfee.Text = "-";
                lblcoach.Text = "-";
                lbltot.Text = "-";
                label17.Text = "-";
                label5.Text = "-";
                addhr.Text = "";
                combrt.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Main_menu().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (int.TryParse(addhr.Text, out int addhor) && int.TryParse(combrt.Text, out int combrate))
            {
                int totadd = addhor * combrate;
                label5.Text = totadd.ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (int.TryParse(label5.Text, out int add) && int.TryParse(lbltot.Text, out int tot))
            {
                int totadd = add + tot;
                lbltot.Text = totadd.ToString();
                MessageBox.Show("Added Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label16.Text == "-" || lblmembfee.Text == "-" || lblmtchfee.Text == "-" || lblcoach.Text == "-" || lbltot.Text == "-" || label17.Text == "-")

            {
                MessageBox.Show("Please fill out all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                payout pay = new payout();
                pay.MemberName = label17.Text;
                pay.MemberID = label16.Text;
                pay.TotalPayment = lbltot.Text;
                pay.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}