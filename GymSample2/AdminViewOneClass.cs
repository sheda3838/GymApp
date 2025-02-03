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
    public partial class AdminViewOneClass : Form
    {
        public int classID;
        public AdminViewOneClass(int classID)
        {
            InitializeComponent();
            this.classID = classID;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            AdminViewAllClasses adminViewAllClasses = new AdminViewAllClasses();
            adminViewAllClasses.Show();
            this.Hide();
        }

        private void AdminViewOneClass_Load(object sender, EventArgs e)
        {
            Classes c = ClassManager.ViewClass(classID);

            if (c != null)
            {
                lblclassID.Text = $"Class ID: {c.ClassID}\n\n" +
                       $"Trainer ID : {c.getTrainerID().ToString()}\n\n " +
                       $"Class Name: {c.getClassName()}\n\n" +
                       $"Description: {c.getClassDescription()}\n\n" +
                       $"Date: {c.getDate().ToString("yyyy-MM-dd")}\n\n" +
                       $"Max Participants: {c.getMaxParticipants()}\n\n" +
                       $"Current Participants: {c.CurrentParticipants}"; // Add current participants

                List<int> memberIDs = ClassManager.GetMembersInClass(classID);

                if (memberIDs.Count > 0)
                {
                    string membersList = string.Join(", ", memberIDs);
                    lblclassmembers.Text = $"Class Member ID's : {membersList}";
                }
                else
                {
                    lblclassmembers.Text = "No members are enrolled yet!!";
                }
            }
        }

        private void lblclassID_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want delete this class!!", "COnfirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.Yes)
            {
                bool isDeleted = ClassManager.DeleteClass(classID);

                if (isDeleted)
                {
                    MessageBox.Show("Class Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdminViewAllClasses adminViewAllClasses = new AdminViewAllClasses();
                    adminViewAllClasses.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error Deleteing Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainerUpdateClassForm trainerUpdateClassForm = new TrainerUpdateClassForm(classID);
            trainerUpdateClassForm.Show();
        }

        private void removemembersbtn_Click(object sender, EventArgs e)
        {
            List<int> memberIDs = ClassManager.GetMembersInClass(classID);

            //validating there are members to remove from the class
            if (memberIDs.Count > 0)
            {
                TrainerDeleteMemberFromClassForm deleteMemberFromClassForm = new TrainerDeleteMemberFromClassForm(classID);
                deleteMemberFromClassForm.Show();
            }
            else
            {
                MessageBox.Show("No members to remove from class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblclassmembers_Click(object sender, EventArgs e)
        {

        }
    }
}
