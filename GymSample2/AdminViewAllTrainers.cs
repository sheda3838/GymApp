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
    public partial class AdminViewAllTrainers : Form
    {
        public AdminViewAllTrainers()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ViewAllTrainers_Load(object sender, EventArgs e)
        {
            InitializeGrid();  
            
            List<Trainer> trainers = TrainerManager.GetAllTariner();

            foreach (Trainer trainer in trainers)
            {
                int rowIndex = AllTrainersGrid.Rows.Add();
                AllTrainersGrid.Rows[rowIndex].Cells[0].Value = trainer.TrainerID;
                AllTrainersGrid.Rows[rowIndex].Cells[1].Value = trainer.getName();
                AllTrainersGrid.Rows[rowIndex].Cells[2].Value = trainer.getEmail();
                AllTrainersGrid.Rows[rowIndex].Cells[3].Value = trainer.getAge();
                AllTrainersGrid.Rows[rowIndex].Cells[4].Value = trainer.getPhoneNumber();
                AllTrainersGrid.Rows[rowIndex].Cells[5].Value = trainer.getUserName();
                AllTrainersGrid.Rows[rowIndex].Cells[6].Value = trainer.getTrainerSpecialization();
                AllTrainersGrid.Rows[rowIndex].Cells[7].Value = trainer.getSalary();
            }
        }

        private void InitializeGrid()
        {
            AllTrainersGrid.Columns.Add("TrainerID", "Trainer ID");
            AllTrainersGrid.Columns.Add("Name", "Name");
            AllTrainersGrid.Columns.Add("Email", "Email");
            AllTrainersGrid.Columns.Add("Age", "Age");
            AllTrainersGrid.Columns.Add("PhoneNumber", "Phone Number");
            AllTrainersGrid.Columns.Add("Username", "Username");
            AllTrainersGrid.Columns.Add("Specialization", "Specialization");
            AllTrainersGrid.Columns.Add("Salary", "Salary");


            // Add a button column for actions
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "DetailsButton";
            buttonColumn.HeaderText = "Actions";
            buttonColumn.Text = "View Trainer";
            buttonColumn.UseColumnTextForButtonValue = true; // Set the button text

            AllTrainersGrid.Columns.Add(buttonColumn);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AdminHomePage adminHomePage = new AdminHomePage();
            adminHomePage.Show();
            this.Hide();
        }

        private void AllTrainersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AllTrainersGrid.Columns["DetailsButton"].Index && e.RowIndex >= 0)
            {
                // Retrieve ClassID from the clicked row
                Trainer.LoggedInTrainerUserName = (AllTrainersGrid.Rows[e.RowIndex].Cells["Username"].Value).ToString();
                Trainer.LoggedInTrainerID= Convert.ToInt32(AllTrainersGrid.Rows[e.RowIndex].Cells["TrainerID"].Value);


                AdminViewOneTrainer AdminViewOneTrainer = new AdminViewOneTrainer();
                AdminViewOneTrainer.Show();
                this.Hide();
            }
        }
    }
}
