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
    public partial class MemberViewProfileForm : Form
    {
        public MemberViewProfileForm()
        {
            InitializeComponent();
        }

        private void viewprofilebtn_Click(object sender, EventArgs e)
        {

        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            
        }


        private void deletebtn_Click(object sender, EventArgs e)
        {
            
        }

        private void ViewMemberForm_Load(object sender, EventArgs e)
        {
            string userName = Member.LoggedInMemberUserName;

            Member memberDetails = Member.GetMemberDetails(userName);


            lblMemberID.Text = $"Member ID: {memberDetails.MemberID.ToString()}\n\n" +
                               $"Name: {memberDetails.getName()}\n\n" +
                               $"Email: {memberDetails.getEmail()}\n\n" +
                               $"Age: {memberDetails.getAge().ToString()}\n\n" +
                               $"Phone Number: {memberDetails.getPhoneNumber()}\n\n" +
                               $"Membership Type: {memberDetails.getMembershipType()}\n\n" +
                               $"Start Date: {memberDetails.getStartDate().ToString("yyyy-MM-dd")}";
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            MembersHomePage membersHomePage = new MembersHomePage();
            membersHomePage.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MembersHomePage membersHomePage = new MembersHomePage();
            membersHomePage.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MemberUpdateProfileForm updateMemberForm = new MemberUpdateProfileForm();
            updateMemberForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete your profile?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Call DeleteMember method to delete profile
                string loggedInUserName = Member.LoggedInMemberUserName;

                bool isDeleted = Member.DeleteMember(loggedInUserName);

                // Show a message based on whether the deletion was successful
                if (isDeleted)
                {
                    MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MemberSignUpForm signUpForm = new MemberSignUpForm();
                    signUpForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error deleting profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
