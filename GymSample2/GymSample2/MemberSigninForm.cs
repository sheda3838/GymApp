using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymSample2
{
    public partial class MemberSigninForm : Form
    {
        public MemberSigninForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signinbtn_Click(object sender, EventArgs e)
        {
            string userName = txtusername.Text;
            string password = txtpassword.Text;

            // Validate the input
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Call the SearchMember method to verify the credentials
            bool isValidUser = Member.SearchMember(userName, password);

            if (isValidUser)
            {
                MessageBox.Show("Sign-in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Member.LoggedInMemberUserName = userName;

                MembersHomePage membersHomePage = new MembersHomePage();
                membersHomePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MemberSignUpForm memberSignUp = new MemberSignUpForm();
            memberSignUp.Show();
            this.Hide();
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

        private void ClearFormInputs()
        {

            txtusername.Clear();
            txtpassword.Clear();

            txtusername.Focus();
        }
        private void resetbtn_Click(object sender, EventArgs e)
        {
            ClearFormInputs();
        }

        private void MemberSigninForm_Load(object sender, EventArgs e)
        {
            txtusername.Focus();

        }


        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Home_Page homepage = new Home_Page();
            homepage.Show();
            this.Hide();
        }
    }
}
