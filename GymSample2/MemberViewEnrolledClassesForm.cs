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
    public partial class MemberViewEnrolledClassesForm : Form
    {
        private List<Classes> classesList; // Stores all classes for the trainer
        private int currentClassIndex = 0; // Tracks the current class being displayed
        private int currentClassID;

        public MemberViewEnrolledClassesForm()
        {
            InitializeComponent();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void ViewMemberClassForm_Load(object sender, EventArgs e)
        {
            classesList = ClassManager.GetClassesByUserID(Member.LoggedInMemberID);

             DisplayClass(currentClassIndex);
        }

        private void DisplayClass(int index)
        {
            // Check if the index is valid
            if (index >= 0 && index < classesList.Count)
            {
                Classes memberclass = classesList[index];
                currentClassID = memberclass.ClassID;

                UpdateNavigationButtons();


                // Display class details using labels
                lblclassID.Text = $"Class ID: {memberclass.ClassID}\n\n" +
                                       $"Trainer ID : {memberclass.getTrainerID().ToString()}\n\n" +
                                       $"Name: {memberclass.getClassName()}\n\n" +
                                       $"Description: {memberclass.getClassDescription()}\n\n" +
                                       $"Date: {memberclass.getDate().ToString("yyyy-MM-dd")}\n\n" +
                                       $"Max Participants: {memberclass.getMaxParticipants()}\n\n" +
                                       $"Current Participants: {memberclass.CurrentParticipants}";

            }
            else
            {
                MessageBox.Show("No more classes to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MembersHomePage membersHomePage = new MembersHomePage();
                membersHomePage.Show();
                this.Hide();
                return;
            }
        }

        private void previousbtn_Click(object sender, EventArgs e)
        {
            if (currentClassIndex > 0) // Check if it's not the first class
            {
                currentClassIndex--; // Move to the previous class
                DisplayClass(currentClassIndex); // Display the previous class
                UpdateNavigationButtons();
            }

        }

        private void nextbtn_Click(object sender, EventArgs e)
        {
            if (currentClassIndex < classesList.Count - 1) //Checks  if the current index is not the last one -1
            {
                currentClassIndex++; // Move to the next class
                DisplayClass(currentClassIndex); // Display the next class
                UpdateNavigationButtons();
            }

        }

        private void UpdateNavigationButtons()
        {
            previousbtn.Enabled = currentClassIndex > 0;

            nextbtn.Enabled = currentClassIndex < classesList.Count - 1;
        }

        private void leavebtn_Click(object sender, EventArgs e)
        {
            bool isLeft = ClassManager.DeleteMemberFromClass(currentClassID, Member.LoggedInMemberID);

            if (isLeft)
            {
                MessageBox.Show("Successfully Dropped from the class!!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MembersHomePage membersHomePage = new MembersHomePage();
                membersHomePage.Show();
                this.Close();

                if (currentClassIndex >= 0)
                {
                    MemberViewEnrolledClassesForm viewMemberClassForm = new MemberViewEnrolledClassesForm();
                    viewMemberClassForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No more classes to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    MemberJoinClassesForm memberClassesForm1 = new MemberJoinClassesForm();
                    memberClassesForm1.Show();
                    this.Hide();
                    return;
                }

                DisplayClass(currentClassIndex);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MembersHomePage membersHomePage = new MembersHomePage();
            membersHomePage.Show();
            this.Hide();
        }
    }
}
