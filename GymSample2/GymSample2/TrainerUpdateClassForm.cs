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
    public partial class TrainerUpdateClassForm : Form
    {
        private int classID;
        public TrainerUpdateClassForm(int currentClassID)
        {
            InitializeComponent();
            classID = currentClassID;
        }

        private void updateclassbtn_Click(object sender, EventArgs e)
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
                return;
            }

            if (maxParticipants < 5)
            {
                MessageBox.Show("To create a class You must have atleast 5 participants.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            bool isUpdated = Classes.UpdateClass(classID,className,description, date, maxParticipants);

            if (isUpdated)
            {
                MessageBox.Show("Class Updated Successfully!", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);

                TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
                viewTrainerClassForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error Updating Class!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
                viewTrainerClassForm.Show();
                this.Hide();
            }
        }

        private void TrainerUpdateClassForm_Load(object sender, EventArgs e)
        {
            Classes updateClass = Classes.GetClassById(classID);

            if (updateClass != null)
            {
                txtclassname.Text = updateClass.getClassName();
                txtclassdescription.Text = updateClass.getClassDescription();
                txtdate.Value = updateClass.getDate();
                txtmaxparticipants.Value = updateClass.getMaxParticipants();
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
            viewTrainerClassForm.Show();
            this.Hide();
        }
    }
}
