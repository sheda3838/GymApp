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
    public partial class TrainerUpdateProfileForm : Form
    {

        public TrainerUpdateProfileForm()
        {
            InitializeComponent();
        }

        private void UpdateTrainerForm_Load(object sender, EventArgs e)
        {
            // Add Specializations  to ComboBox
            txttrainerspecialization.Items.Add("Strength");
            txttrainerspecialization.Items.Add("Pilates");
            txttrainerspecialization.Items.Add("Yoga");
            txttrainerspecialization.Items.Add("Cardio");
            txttrainerspecialization.Items.Add("Flexibility");

            txttrainerspecialization.SelectedIndex = 0;  // This will set "Strength" as default

            string userName = Trainer.LoggedInTrainerUserName;
            Trainer trainer = (Trainer)TrainerManager.ViewTrainer(userName);

            txtname.Text = trainer.getName();
            txtemail.Text = trainer.getEmail();
            txtage.Text = trainer.getAge().ToString();
            txtphonenumber.Text = trainer.getPhoneNumber();
            txttrainerspecialization.Text = trainer.getTrainerSpecialization();
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string updatedName = txtname.Text;
            string updatedEmail = txtemail.Text;
            int updatedAge = int.Parse(txtage.Text);
            string updatedPhoneNumber = txtphonenumber.Text;
            string updatespecialization = txttrainerspecialization.SelectedItem.ToString();

            string loggedinusername = Trainer.LoggedInTrainerUserName;


            bool isUpdated = TrainerManager.UpdateTrainer(loggedinusername,updatedName, updatedEmail, updatedAge, updatedPhoneNumber, updatespecialization);

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

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            TrainerViewProfileForm viewTrainerForm = new TrainerViewProfileForm();
            viewTrainerForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainerViewProfileForm trainerViewProfileForm = new TrainerViewProfileForm();
            trainerViewProfileForm.Show();
            this.Hide();
        }
    }
}
