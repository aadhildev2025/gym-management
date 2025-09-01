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
    public partial class Member : Form
    {
        public Member()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(membID.Text) || string.IsNullOrEmpty(membname.Text) || string.IsNullOrEmpty(wekg.Text) 
               || string.IsNullOrEmpty(no_mtch.Text) || string.IsNullOrEmpty(no_coach.Text) || string.IsNullOrEmpty(combplan.Text) 
               || string.IsNullOrEmpty(combomemb.Text) || string.IsNullOrEmpty(combmtch.Text) || string.IsNullOrEmpty(combcoach.Text))
            {
                MessageBox.Show("Fill the empty field", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }


            CalculateMembershipFee();


            CalculateMatchFee();


            CalculateCoachFee();


            CalculateTotalPayment();
        }

        private void CalculateMembershipFee()
        {
            if (combplan.Text.Equals("1. Annual"))
            {
                if (combomemb.Text.Equals("Individual (Adult over 18 years)"))
                    membfee.Text = lblmembfee.Text = "5000";
                else if (combomemb.Text.Equals("Family (2 adults and any number of children – full time students up to age 25 or less as of 25/10/2022)"))
                    membfee.Text = lblmembfee.Text = "7000";
                else if (combomemb.Text.Equals("Junior/Intermediate (Full time student up to the age of 25 or less as at 25/10/2022)"))
                    membfee.Text = lblmembfee.Text = "3000";
            }
            else if (combplan.Text.Equals("2. 6 Months"))
            {
                if (combomemb.Text.Equals("Individual (Adult over 18 years)"))
                    membfee.Text = lblmembfee.Text = "3000";
                else if (combomemb.Text.Equals("Family (2 adults and any number of children – full time students up to age 25 or less as of 25/10/2022)"))
                    membfee.Text = lblmembfee.Text = "5000";
                else if (combomemb.Text.Equals("Junior/Intermediate (Full time student up to the age of 25 or less as at 25/10/2022)"))
                    membfee.Text = lblmembfee.Text = "2000";
            }
            else if (combplan.Text.Equals("3. 3 Months"))
            {
                if (combomemb.Text.Equals("Individual (Adult over 18 years)"))
                    membfee.Text = lblmembfee.Text = "2500";
                else if (combomemb.Text.Equals("Family (2 adults and any number of children – full time students up to age 25 or less as of 25/10/2022)"))
                    membfee.Text = lblmembfee.Text = "3500";
            }
            else if (combplan.Text.Equals("4. 1 Month"))
            {
                if (combomemb.Text.Equals("Individual (Adult over 18 years)"))
                    membfee.Text = lblmembfee.Text = "2000";
                else if (combomemb.Text.Equals("Family (2 adults and any number of children – full time students up to age 25 or less as of 25/10/2022)"))
                    membfee.Text = lblmembfee.Text = "2500";
            }
        }

        private void CalculateMatchFee()
        {
            int noOFmtch;
            int matchFee;
            if (int.TryParse(no_mtch.Text, out noOFmtch) && int.TryParse(combmtch.Text, out matchFee))
            {
                int totmtchfee = noOFmtch * matchFee;
                lblmtchfee.Text = totmtchfee.ToString();
            }
        }

        private void CalculateCoachFee()
        {
            int coach_hr;
            int coachFee;
            if (int.TryParse(no_coach.Text, out coach_hr) && int.TryParse(combcoach.Text, out coachFee))
            {
                int totcoachfee = coach_hr * coachFee;
                lblcoach.Text = totcoachfee.ToString();
            }
        }

        private void CalculateTotalPayment()
        {
            int matchfee;
            int memfee;
            int coachfee;
            if (int.TryParse(lblmtchfee.Text, out matchfee) && int.TryParse(lblmembfee.Text, out memfee) && int.TryParse(lblcoach.Text, out coachfee))
            {
                int totalpayment = matchfee + memfee + coachfee;
                lbltot.Text = totalpayment.ToString();
            }

            int membrID;
            if (int.TryParse(membID.Text, out membrID))
                label16.Text = membrID.ToString();
            label17.Text = membname.Text;
        }

        private void membfee_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Main_menu().Show();
            this.Hide();
        }

        private void membID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                membID.Text = "";
                membname.Text = "";
                wekg.Text = "";
                no_mtch.Text = "";
                no_coach.Text = "";
                combplan.Text = "";
                combomemb.Text = "";
                combmtch.Text = "";
                combcoach.Text = "";
                membfee.Text = "";
                label16.Text = "-";
                lblmembfee.Text = "-";
                lblmtchfee.Text = "-";
                lblcoach.Text = "-";
                lbltot.Text = "-";
                label17.Text = "-";
                dataGridView1.DataSource = null;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrEmpty(membID.Text) || string.IsNullOrEmpty(membname.Text) || string.IsNullOrEmpty(wekg.Text) 
                   || string.IsNullOrEmpty(no_mtch.Text) || string.IsNullOrEmpty(no_coach.Text) || string.IsNullOrEmpty(combplan.Text) 
                   || string.IsNullOrEmpty(combomemb.Text) || string.IsNullOrEmpty(combmtch.Text) || string.IsNullOrEmpty(combcoach.Text))
                {
                    MessageBox.Show("Please fill out Empty Fields in Details", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
                else
                {
                    int memeID = int.Parse(membID.Text);
                    string meme_NAME = membname.Text;
                    String WeightKG = wekg.Text;
                    int noOFmatch = int.Parse(no_mtch.Text);
                    int coach_hr = int.Parse(no_coach.Text);
                    string memshipPLAN = combplan.Text;
                    string memshipTYPE = combomemb.Text;
                    int memFee = int.Parse(membfee.Text);
                    int matchFee = int.Parse(combmtch.Text);
                    int coachFee = int.Parse(combcoach.Text);
                    int Totalpayment = int.Parse(lbltot.Text);
                    int MATCHfee = int.Parse(lblmtchfee.Text);
                    int MEMfee = int.Parse(lblmembfee.Text);
                    int COACHfee = int.Parse(lblcoach.Text);

                    // decaring sql connection
                    using (SqlConnection Sqlcon = new SqlConnection("Data Source=AADHIL\\SQLEXPRESS;Initial Catalog=MadZoo_GYM;Integrated Security=True"))
                    {
                        Sqlcon.Open();

                        // SQL query with parameters for insert
                        string query = "INSERT INTO MadZoo_GYM VALUES (@MEM_ID, @MEM_Name, @MEM_Weight, @NOof_matches, @Coaching_hr, @MEMship_plan, @MEMship_type, @MEMfee, @matchFEE, @CoachingFEE, @total_Payment)";
                        using (SqlCommand sqlcmd = new SqlCommand(query, Sqlcon))
                        {
                            // Assign parameters
                            sqlcmd.Parameters.AddWithValue("@MEM_ID", memeID);
                            sqlcmd.Parameters.AddWithValue("@MEM_Name", membname.Text);
                            sqlcmd.Parameters.AddWithValue("@MEM_Weight", wekg.Text);
                            sqlcmd.Parameters.AddWithValue("@NOof_matches", noOFmatch);
                            sqlcmd.Parameters.AddWithValue("@Coaching_hr", coach_hr);
                            sqlcmd.Parameters.AddWithValue("@MEMship_plan", combplan.Text);
                            sqlcmd.Parameters.AddWithValue("@MEMship_type", combomemb.Text);
                            sqlcmd.Parameters.AddWithValue("@MEMfee", memFee);
                            sqlcmd.Parameters.AddWithValue("@matchFEE", MATCHfee);
                            sqlcmd.Parameters.AddWithValue("@CoachingFEE", COACHfee);
                            sqlcmd.Parameters.AddWithValue("@total_Payment", Totalpayment);

                            // Execute the insert query
                            sqlcmd.ExecuteNonQuery();

                            // Closing the connection
                            Sqlcon.Close();

                            MessageBox.Show("Added Successfully");
                        }
                    }
                }
            }
        }
    
                private void button4_Click(object sender, EventArgs e)
                {
            if (string.IsNullOrEmpty(membID.Text))
            {
                MessageBox.Show("Please fill out Empty Fields in Details", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                int memID = int.Parse(membID.Text);

                // decaring sql connection
                SqlConnection Sqlcon = new SqlConnection("Data source = AADHIL\\SQLEXPRESS; initial catalog= MadZoo_GYM ; integrated security = true");

                Sqlcon.Open();

                //Sql query
                SqlCommand sqlcmd = new SqlCommand("delete from MadZoo_GYM where MEM_ID=@MEM_ID", Sqlcon);

                // equalling parameter to relevent columns
                sqlcmd.Parameters.AddWithValue("@MEM_ID", memID);


                //to exucute
                sqlcmd.ExecuteNonQuery();

                //closing the connection
                Sqlcon.Close();


                MessageBox.Show("Deleted Successfully");

            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
                int userId;
                if (int.TryParse(membID.Text, out userId))
                {
                    using (SqlConnection connection = new SqlConnection("Data source = AADHIL\\SQLEXPRESS; initial catalog= MadZoo_GYM ; integrated security = true"))
                    {
                        connection.Open();
                        string query = "SELECT * FROM MadZoo_GYM WHERE MEM_ID = @MEM_ID;";

                        Console.WriteLine($"Executing SQL query: {query}");

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MEM_ID", userId);


                            DataTable dataTable = new DataTable();

                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                dataTable.Load(reader);
                            }


                            dataGridView1.DataSource = dataTable;


                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("User not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid numeric User ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void lblmembfee_Click(object sender, EventArgs e)
        {

        }

        private void lblmtchfee_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void lblcoach_Click(object sender, EventArgs e)
        {

        }

        private void lbltot_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
