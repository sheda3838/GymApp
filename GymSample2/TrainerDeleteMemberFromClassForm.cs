using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymSample2
{
    public partial class TrainerDeleteMemberFromClassForm : Form
    {
        private int classID;
        public TrainerDeleteMemberFromClassForm(int classID)
        {
            InitializeComponent();
            this.classID = classID;
        }

        private void removebtn_Click(object sender, EventArgs e)
        {
            int memberID;
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                MessageBox.Show("Please enter member ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.TryParse(txtMemberID.Text, out memberID))
                { 
                var confirmation = MessageBox.Show("Are you sure you want to remove this member form class", "Remove Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmation == DialogResult.Yes)
                {
                    bool isDeleted =  ClassManager.DeleteMemberFromClass(classID, memberID);

                    if (isDeleted)
                    {
                        MessageBox.Show("Member removed successfully!", "Success",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error removing member", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
            viewTrainerClassForm.Show();
            this.Hide();

        }

        private void DeleteMemberFromClassForm_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TrainerViewCreatedClassForm trainerViewCreatedClassForm = new TrainerViewCreatedClassForm();
            trainerViewCreatedClassForm.Show();
            this.Hide();
        }
    }
}
