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
    public partial class AdminViewOneTrainer : Form
    {
        public AdminViewOneTrainer()
        {
            InitializeComponent();
        }

        private void AdminViewOneTrainer_Load(object sender, EventArgs e)
        {
            string userName = Trainer.LoggedInTrainerUserName;
            Trainer trainerDetails = (Trainer)TrainerManager.ViewTrainer(userName);

            lblTrainerID.Text = $"Trainer ID :  {trainerDetails.TrainerID.ToString()}\n\n " +
                                $"Name :   {trainerDetails.getName()}\n\n " +
                                $"Email :  {trainerDetails.getEmail()}\n\n " +
                                $"Age : {trainerDetails.getAge().ToString()}\n\n " +
                                $"Phone Number :  {trainerDetails.getPhoneNumber()}\n\n " +
                                $"Specialization :  {trainerDetails.getTrainerSpecialization()}\n\n" +
                                $"Salary : {trainerDetails.getSalary()}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainerUpdateProfileForm trainerUpdateProfileForm = new TrainerUpdateProfileForm();
            trainerUpdateProfileForm.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var confiramation = MessageBox.Show("Are you sure u want to delete this Trainer account!!!", "Confiramation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confiramation == DialogResult.Yes)
            {
                bool isdeleted = TrainerManager.DeleteTrainer(Trainer.LoggedInTrainerUserName);

                if (isdeleted)
                {
                    MessageBox.Show("Profile deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AdminViewAllTrainers adminViewAllTrainers = new AdminViewAllTrainers();
                    adminViewAllTrainers.Show();
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
            AdminViewAllTrainers adminViewAllTrainers = new AdminViewAllTrainers();
            adminViewAllTrainers.Show();
            this.Hide();
        }
    }
}
