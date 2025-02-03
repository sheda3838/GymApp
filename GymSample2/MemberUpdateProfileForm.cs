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
    public partial class MemberUpdateProfileForm : Form
    {

        public MemberUpdateProfileForm()
        {
            InitializeComponent();
        }

        private void UpdateMemberForm_Load(object sender, EventArgs e)
        {
            // Add Membership Types to ComboBox
            txtmembershiptype.Items.Add("Standard");
            txtmembershiptype.Items.Add("Premium");
            txtmembershiptype.Items.Add("VIP");

            txtmembershiptype.SelectedIndex = 0;  // This will set "Standard" as default

            string userName = Member.LoggedInMemberUserName;
            Member member = (Member)MemberManager.ViewMember(userName);

            txtname.Text = member.getName();
            txtemail.Text = member.getEmail();
            txtage.Text = member.getAge().ToString();
            txtphonenumber.Text = member.getPhoneNumber();
            txtmembershiptype.Text = member.getMembershipType();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string loggedInUserName = Member.LoggedInMemberUserName;

            // Collect the updated data from the form controls
            string updatedName = txtname.Text;
            string updatedEmail = txtemail.Text;
            int updatedAge = int.Parse(txtage.Text); 
            string updatedPhoneNumber = txtphonenumber.Text;
            string updatedMembershipType = txtmembershiptype.SelectedItem.ToString(); 

            // Call the update method to save the updated data to the database
            bool isUpdated = MemberManager.UpdateMember(loggedInUserName,updatedName,updatedEmail,updatedAge,updatedPhoneNumber,updatedMembershipType);

            // Show a message based on whether the update was successful
            if (isUpdated)
            {
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error updating profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MemberViewProfileForm viewMemberForm = new MemberViewProfileForm();
            viewMemberForm.Show();
            this.Hide();
        }
    }
}
