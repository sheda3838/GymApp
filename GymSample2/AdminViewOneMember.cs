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
    public partial class AdminViewOneMember : Form
    {
        public AdminViewOneMember()
        {
            InitializeComponent();
        }

        private void AdminViewOneMember_Load(object sender, EventArgs e)
        {
            Member memberDetails = (Member)MemberManager.ViewMember(Member.LoggedInMemberUserName);

            if (memberDetails != null)
            {
                lblMemberID.Text = $"Member ID: {memberDetails.MemberID.ToString()}\n\n" +
                                   $"Name: {memberDetails.getName()}\n\n" +
                                   $"Email: {memberDetails.getEmail()}\n\n" +
                                   $"Age: {memberDetails.getAge().ToString()}\n\n" +
                                   $"Phone Number: {memberDetails.getPhoneNumber()}\n\n" +
                                   $"Membership Type: {memberDetails.getMembershipType()}\n\n" +
                                   $"Start Date: {memberDetails.getStartDate().ToString("yyyy-MM-dd")}";
            }
            else
            {
                MessageBox.Show("Member details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MemberUpdateProfileForm memberUpdateProfileForm = new MemberUpdateProfileForm();
            memberUpdateProfileForm.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AdminViewAllMembers adminViewAllMembers = new AdminViewAllMembers();
            adminViewAllMembers.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confiramtion = MessageBox.Show("Are you sure you want to delete this members account!!", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult.Yes == confiramtion)
            {
                bool isDeleted = MemberManager.DeleteMember(Member.LoggedInMemberUserName);

                if (isDeleted)
                {
                    MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdminViewAllMembers adminViewAllMembers = new AdminViewAllMembers();
                    adminViewAllMembers.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error deleting profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            List<Attendance> attendanceHistory = AttendanceManager.GetMemberAttendance(Member.LoggedInMemberID);

            if (attendanceHistory.Count > 0)
            {
                MemberAttendanceForm memberAttendanceForm = new MemberAttendanceForm();
                memberAttendanceForm.Show();
            }
            else
            {
                MessageBox.Show("No attendance to display!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
