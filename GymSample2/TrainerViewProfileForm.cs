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
    public partial class TrainerViewProfileForm : Form
    {

        public TrainerViewProfileForm()
        {
            InitializeComponent();
        }

        private void viewprofilebtn_Click(object sender, EventArgs e)
        {

        }

        private void updateprofilebtn_Click(object sender, EventArgs e)
        {
            
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

        }

        private void ViewTrainerForm_Load(object sender, EventArgs e)
        {
            string userName = Trainer.LoggedInTrainerUserName;
            Trainer t = new Trainer();
            Trainer trainerDetails = (Trainer)TrainerManager.ViewTrainer(userName);

            lblTrainerID.Text = $"Trainer ID :  {trainerDetails.TrainerID.ToString()}\n\n " +
                                $"Name :   {trainerDetails.getName()}\n\n " +
                                $"Email :  {trainerDetails.getEmail()}\n\n " +
                                $"Age : {trainerDetails.getAge().ToString()}\n\n " +
                                $"Phone Number :  {trainerDetails.getPhoneNumber()}\n\n "+
                                $"Specialization :  {trainerDetails.getTrainerSpecialization()}\n\n" +
                                $"Salary : {trainerDetails.getSalary()}";
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            TrainersHomePage trainersHomePage = new TrainersHomePage();
            trainersHomePage.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainerUpdateProfileForm updateTrainerForm = new TrainerUpdateProfileForm();
            updateTrainerForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete your profile?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Call delettrainer method to delete profile
                string loggedInUserName = Trainer.LoggedInTrainerUserName;

                bool isDeleted = TrainerManager.DeleteTrainer(loggedInUserName);

                // Show a message based on whether the deletion was successful
                if (isDeleted)
                {
                    MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    TrainerSignUpForm trainerSignUpForm = new TrainerSignUpForm();
                    trainerSignUpForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Error deleting profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TrainersHomePage homePage = new TrainersHomePage();
            homePage.Show();
            this.Hide();
        }
    }
}
