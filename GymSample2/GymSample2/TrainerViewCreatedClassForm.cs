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
    public partial class TrainerViewCreatedClassForm : Form
    {
        private List<Classes> classesList; // Stores all classes for the trainer
        private int currentClassIndex = 0; // Tracks the current class being displayed
        private int currentClassID;

        public TrainerViewCreatedClassForm()
        {
            InitializeComponent();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            TrainersHomePage trainersHomePage = new TrainersHomePage();
            trainersHomePage.Show();
            this.Hide();
        }

        private void ViewTrainerClassForm_Load(object sender, EventArgs e)
        {
            // Fetch classes for the logged-in trainer
            classesList = Classes.GetClassesByTrainerID(Trainer.LoggedInTrainerID);



            // Display the first class if available
            if (classesList != null && classesList.Count > 0)
            {
                UpdateNavigationButtons();

                DisplayClass(currentClassIndex);
            }
            else
            {
                MessageBox.Show("No classes available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayClass(int index)
        {

            Classes trainerClass = classesList[index];
            currentClassID = trainerClass.ClassID;

            // Check if the index is valid
            if (index >= 0 && index < classesList.Count)
            {
                List<int> memberIDs = Classes.GetMembersInClass(currentClassID);

                if (memberIDs.Count > 0)
                {
                    string membersList = string.Join(", ", memberIDs);
                    lblclassmembers.Text = $"Class Member ID's : {membersList}";
                }
                else
                {
                    lblclassmembers.Text = "No members are enrolled yet!!";
                }


                // Display class details using labels
                lblclassID.Text = $"Class ID: {trainerClass.ClassID}\n\n" +
                                       $"Name: {trainerClass.getClassName()}\n\n" +
                                       $"Description: {trainerClass.getClassDescription()}\n\n" +
                                       $"Date: {trainerClass.getDate().ToString("yyyy-MM-dd")}\n\n" +
                                       $"Max Participants: {trainerClass.getMaxParticipants()}\n\n" +
                                       $"Current Participants: {trainerClass.CurrentParticipants}";

            }
            else
            {
                MessageBox.Show("No more classes to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            previousbtn.Enabled = currentClassIndex > 0;

            nextbtn.Enabled = currentClassIndex < classesList.Count - 1;
        }

        private void lblclassID_Click(object sender, EventArgs e)
        {

        }

        private void updateclassbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void dltclassbtn_Click(object sender, EventArgs e)
        {
            
        }

 

        private void removemembersbtn_Click(object sender, EventArgs e)
        {
            List<int> memberIDs = Classes.GetMembersInClass(currentClassID);

            //validating there are members to remove from the class
            if (memberIDs.Count > 0)
            { 
            TrainerDeleteMemberFromClassForm deleteMemberFromClassForm = new TrainerDeleteMemberFromClassForm(currentClassID);
            deleteMemberFromClassForm.Show();
            this.Hide();
            }
            else
            {
                MessageBox.Show("No members to remove from class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TrainersHomePage trainersHomePage = new TrainersHomePage();
            trainersHomePage.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainerUpdateClassForm trainerUpdateClassForm = new TrainerUpdateClassForm(currentClassID);
            trainerUpdateClassForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bool isDeleted = Classes.DeleteClass(currentClassID);

            if (isDeleted)
            {
                MessageBox.Show("Class Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TrainersHomePage trainersHomePage1 = new TrainersHomePage();
                trainersHomePage1.Show();
                this.Hide();

                if (currentClassIndex >= 0)
                {
                    TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
                    viewTrainerClassForm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("No more classes to display.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TrainersHomePage trainersHomePage = new TrainersHomePage();
                    trainersHomePage.Show();
                    this.Hide();
                    return;
                }

                DisplayClass(currentClassIndex);
            }
            else
            {
                MessageBox.Show("Error Deleteing Class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Classes trainerClass = classesList[currentClassIndex];

            //checking trainer marks attendance for classes sheduled on the relevant day
            if (trainerClass.getDate() != DateTime.Today)
            {
                MessageBox.Show("You can only mark attendance for today's class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (trainerClass.getCurrentParticipants() == 0)
            {
                MessageBox.Show("No one has enrolled!! How are you going to mark attendance.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TrainerMarkAttendanceForm markAttendanceForm = new TrainerMarkAttendanceForm(currentClassID);
                markAttendanceForm.Show();
                this.Hide();
            }
        }
    }
}
