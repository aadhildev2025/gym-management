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
    public partial class payout : Form
    {
        public string TotalPayment
        {
            get { return lbltot.Text; }
            set { lbltot.Text = value; }
        }
        public string MemberName
        {
            get { return label17.Text; }
            set { label17.Text = value; }
        }

        public string MemberID
        {
            get { return label16.Text; }
            set { label16.Text = value; }
        }

        public payout()
        {
            InitializeComponent();
        }

        private void lbltot_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you going to cancel the payment?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new addpay().Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment successful!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
