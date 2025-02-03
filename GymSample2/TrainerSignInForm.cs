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
    public partial class TrainerSignInForm : Form
    {
        public TrainerSignInForm()
        {
            InitializeComponent();
        }

        private void TrainerSignInForm_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
        }
    

        public void ClearFormInputs()
        {
            txtusername.Clear();
            txtpassword.Clear();

            txtusername.Focus();
        }

        private void showpasswordbtn_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (showpasswordbtn.Checked)
            {
                // Show the password by setting the PasswordChar to '\0' (no character masking)
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                // Hide the password by setting the PasswordChar back to '*' (character masking)
                txtpassword.PasswordChar = '*';
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            ClearFormInputs();
        }

        private void signupformchange_Click(object sender, EventArgs e)
        {
            TrainerSignUpForm trainerSignUpForm = new TrainerSignUpForm();
            trainerSignUpForm.Show();
            this.Hide();
        }

        private void signinbtn_Click(object sender, EventArgs e)
        {
            string userName = txtusername.Text;
            string password = txtpassword.Text;

            //Validate inputs
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Call search trainer method 
            bool isValidUser = TrainerManager.ValidateTrainer(userName, password);

            if (isValidUser)
            {
                MessageBox.Show("Sign-in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Trainer.LoggedInTrainerUserName = userName;

                TrainersHomePage trainerhomepage = new TrainersHomePage();
                trainerhomepage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
  
        

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home_Page home_Page = new Home_Page();
            home_Page.Show();
            this.Hide();
        }
    }
}
