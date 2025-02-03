using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    public partial class TrainerCreateClassForm : Form
    {
        public TrainerCreateClassForm()
        {
            InitializeComponent();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            TrainersHomePage trainersHomePage = new TrainersHomePage();
            trainersHomePage.Show();
            this.Hide();
        }

        private void submitbtn_Click(object sender, EventArgs e)
        {
            string className = txtclassname.Text;
            string description = txtclassdescription.Text;
            DateTime date = txtdate.Value;
            int maxParticipants = (int)txtmaxparticipants.Value;

            // Validate input
            if (string.IsNullOrEmpty(className) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (date.Date <= DateTime.Now.Date)
            {
                MessageBox.Show("Start date cannot be today or in the past.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            if (maxParticipants < 5 || maxParticipants > 25)
            {
                MessageBox.Show("You can have only participants range of 5 to 25.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ClassManager.IsTrainerAvailableOnDate(Trainer.LoggedInTrainerID, date))
            {
                MessageBox.Show("You already have a class scheduled on this date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }

            // Call CreateClass method
            bool isCreated =ClassManager.CreateClasses(className, description, Trainer.LoggedInTrainerID, date, maxParticipants);

            if (isCreated)
            {
                MessageBox.Show("Class created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
                viewTrainerClassForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error creating class. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TrainersHomePage trainersHomePage = new TrainersHomePage();
            trainersHomePage.Show();
            this.Hide();
        }
    }
}
