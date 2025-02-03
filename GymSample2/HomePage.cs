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
    public partial class Home_Page : Form
    {
        public Home_Page()
        {
            InitializeComponent();
        }


        private void Home_Page_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MemberSigninForm memberSigninForm = new MemberSigninForm();
            memberSigninForm.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            TrainerSignInForm trainerSignInForm = new TrainerSignInForm();
            trainerSignInForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AdminSignIn adminSignIn = new AdminSignIn();
            adminSignIn.Show();
            this.Hide();

            /*AdminHomePage adminHomePage = new AdminHomePage();  
            adminHomePage.Show();
            this.Hide();*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
