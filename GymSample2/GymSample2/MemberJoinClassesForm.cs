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
    public partial class MemberJoinClassesForm : Form
    {
        private List<Classes> classesList; // Stores all classes 
        private int currentClassIndex = 0; // Tracks the current class being displayed
        private int currentClassID;

        public MemberJoinClassesForm()
        {
            InitializeComponent();
        }


        private void MemberViewAllClassesForm_Load(object sender, EventArgs e)
        {
            // Fetch classes for the logged-in trainer
            classesList = Classes.GetAllAvailableClasses();

            // Display the first class if available
            if (classesList != null && classesList.Count > 0)
            {
                DisplayClass(currentClassIndex);
            }
            else
            {
                MessageBox.Show("No classes available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayClass(int index)
        {
            // Check if the index is valid
            if (index >= 0 && index < classesList.Count)
            {
                Classes availableclass = classesList[index];

                currentClassID = availableclass.ClassID;
                UpdateNavigationButtons(); // Ensure buttons are set correctly


                bool isEnrolled = Classes.IsMemberEnrolledInClass(Member.LoggedInMemberID, availableclass.ClassID);

                if (!isEnrolled)
                {
                    joinclsbtn.Enabled = true;
                    leaveclsbtn.Enabled = false;
                }
                else
                {
                    joinclsbtn.Enabled = false;
                    leaveclsbtn.Enabled = true;
                }


                // Display class details using labels
                lblclassID.Text = $"Class ID: {availableclass.ClassID}\n\n" +
                                       $"Trainer ID : {availableclass.getTrainerID().ToString()}\n\n " +
                                       $"Class Name: {availableclass.getClassName()}\n\n" +
                                       $"Description: {availableclass.getClassDescription()}\n\n" +                   
                                       $"Date: {availableclass.getDate().ToString("yyyy-MM-dd")}\n\n" +
                                       $"Max Participants: {availableclass.getMaxParticipants()}\n\n" +
                                       $"Current Participants: {availableclass.CurrentParticipants}"; // Add current participants

            }
            else
            {
                MessageBox.Show("No more classes to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void nextbtn_Click_1(object sender, EventArgs e)
        {
            if (currentClassIndex < classesList.Count - 1) //Checks if classesList is not null and if the current index is not the last one -1
            {
                currentClassIndex++; // Move to the next class
                DisplayClass(currentClassIndex); // Display the next class
                UpdateNavigationButtons();
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

        private void UpdateNavigationButtons()
        {
            // Disable Previous button if at the first class
            previousbtn.Enabled = currentClassIndex > 0;

            // Disable Next button if at the last class
            nextbtn.Enabled = currentClassIndex < classesList.Count - 1;
        }
        private void joinclassbtn_Click(object sender, EventArgs e)
        {
            Classes.JoinClass(currentClassID, Member.LoggedInMemberID);
            DisplayClass(currentClassIndex);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            // Get the Trainer ID from the searchTextBox
            int trainerID = 0;
            if (int.TryParse(txtTrainerID.Text, out trainerID))
            {
                // Call the method to get classes for the specified Trainer ID
                classesList = Classes.GetClassesByTrainerID(trainerID);

                if (classesList != null && classesList.Count > 0)
                {
                    currentClassIndex = 0; // Reset to the first class in the search results
                    DisplayClass(currentClassIndex);
                }
                else
                {
                    MessageBox.Show("No classes found for the given Trainer ID.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Trainer ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewmtclassesbtn_Click(object sender, EventArgs e)
        {
            List <Classes> userclassesList = Classes.GetClassesByUserID(Member.LoggedInMemberID);

            if (userclassesList == null)
            {
                MessageBox.Show("Error retrieving classes. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if there are any classes available
            if (userclassesList.Count == 0)
            {
                MessageBox.Show("No classes are enrolled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MemberViewEnrolledClassesForm viewMemberClassForm = new MemberViewEnrolledClassesForm();
                viewMemberClassForm.Show();
                this.Hide();
            }
        }


        private void joinclsbtn_Click_1(object sender, EventArgs e)
        {
            Classes.JoinClass(currentClassID, Member.LoggedInMemberID);
            DisplayClass(currentClassIndex);
        }

        private void leaveclsbtn_Click_1(object sender, EventArgs e)
        {
            bool isDeleted = Classes.DeleteMemberFromClass(currentClassID, Member.LoggedInMemberID);

            if (isDeleted)
            {
                MessageBox.Show("Sucessfully dropped from class.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DisplayClass(currentClassIndex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MembersHomePage membersHomePage = new MembersHomePage();
            membersHomePage.Show();
            this.Hide();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
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
