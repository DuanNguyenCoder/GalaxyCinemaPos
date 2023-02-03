using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace POS_Galaxy.Ticket_UI
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void monthCalendar1_MouseHover(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            foreach (Guna.UI2.WinForms.Guna2Button item in guna2Panel1.Controls)
            {
                MessageBox.Show(item.Text);
                
            }
        }
    }
}
