using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    public partial class AdminHomePage : Form
    {
        public AdminHomePage()
        {
            InitializeComponent();
        }



        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AdminSignIn adminSign = new AdminSignIn();
            adminSign.Show();
            this.Hide();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminViewAllClasses viewAllClasses = new AdminViewAllClasses();
            viewAllClasses.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AdminViewAllMembers viewAllMembers = new AdminViewAllMembers();
            viewAllMembers.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminViewAllTrainers viewAllTrainers = new AdminViewAllTrainers();
            viewAllTrainers.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AdminViewAllAttendances viewAllAttendances = new AdminViewAllAttendances();
            viewAllAttendances.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AdminHomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
