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
    public partial class TrainersHomePage : Form
    {
        public TrainersHomePage()
        {
            InitializeComponent();
        }

        private void viewprofilebtn_Click(object sender, EventArgs e)
        {
            TrainerViewProfileForm viewTrainerForm = new TrainerViewProfileForm();
            viewTrainerForm.Show();
            this.Hide();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            TrainerSignInForm trainerSignInForm = new TrainerSignInForm();
            trainerSignInForm.Show();
            this.Hide();
        }



        private void viewclassbtn_Click(object sender, EventArgs e)
        {
            TrainerViewCreatedClassForm viewtrainerclassform = new TrainerViewCreatedClassForm();
            viewtrainerclassform.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void TrainersHomePage_Load(object sender, EventArgs e)
        {

        }

        private void createclassbtn_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TrainerCreateClassForm createclassform = new TrainerCreateClassForm();
            createclassform.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            List<Classes> classesList = ClassManager.GetClassesByTrainerID(Trainer.LoggedInTrainerID);

            if (classesList != null && classesList.Count > 0)
            {
                TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
                viewTrainerClassForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No classes to display", "Infor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TrainerViewProfileForm viewTrainerForm = new TrainerViewProfileForm();
            viewTrainerForm.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TrainerSignInForm trainerSignInForm = new TrainerSignInForm();
            trainerSignInForm.Show();   
            this.Hide();
        }
    }
}
