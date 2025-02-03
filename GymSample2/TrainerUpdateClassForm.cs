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

            if (maxParticipants < 5 || maxParticipants > 25 )
            {
                MessageBox.Show("You can have only participants range of 5 to 25..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //checks user reducing the number of max particiants after class is full
            if (maxParticipants < ClassManager.GetMembersInClass(classID).Count)
            {
                MessageBox.Show("Class is full..You cant reduce the number of max participants..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isUpdated = ClassManager.UpdateClass(classID,className,description, date, maxParticipants);

            if (isUpdated)
            {
                MessageBox.Show("Class Updated Successfully!", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error Updating Class!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TrainerUpdateClassForm_Load(object sender, EventArgs e)
        {
            Classes updateClass = ClassManager.ViewClass(classID);

            if (updateClass != null)
            {
                txtclassname.Text = updateClass.getClassName();
                txtclassdescription.Text = updateClass.getClassDescription();
                txtdate.Value = updateClass.getDate();
                txtmaxparticipants.Value = updateClass.getMaxParticipants();
            }
        }

    }
}
