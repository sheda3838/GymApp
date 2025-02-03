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
    public partial class AdminViewAllClasses : Form
    {
        public AdminViewAllClasses()
        {
            InitializeComponent();
        }

        private void allClassesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == allClassesGrid.Columns["DetailsButton"].Index && e.RowIndex >= 0)
            {
                // Retrieve ClassID from the clicked row
                var classID = Convert.ToInt32(allClassesGrid.Rows[e.RowIndex].Cells["ClassID"].Value);


                AdminViewOneClass adminViewOneClass = new AdminViewOneClass(classID);
                adminViewOneClass.Show();
                this.Hide();
            }
        }

        private void InitilaizeGrid()
        {
            allClassesGrid.Columns.Add("ClassID", "Class ID");
            allClassesGrid.Columns.Add("ClassName", "Class Name");
            allClassesGrid.Columns.Add("ClassDescription", "Class Description");
            allClassesGrid.Columns.Add("MaxParticipants", "Max Participants");
            allClassesGrid.Columns.Add("TrainerID", "Trainer ID");
            allClassesGrid.Columns.Add("Date", "Date");

            // Add a button column for actions
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "DetailsButton";
            buttonColumn.HeaderText = "Actions";
            buttonColumn.Text = "View Class";
            buttonColumn.UseColumnTextForButtonValue = true; // Set the button text

            allClassesGrid.Columns.Add(buttonColumn);
        }

        private void ViewAllClasses_Load(object sender, EventArgs e)
        {
            InitilaizeGrid();

            List<Classes> classes = ClassManager.GetAllClasses();

            foreach (Classes c in classes)
            {
                int rowIndex = allClassesGrid.Rows.Add();
                allClassesGrid.Rows[rowIndex].Cells[0].Value = c.ClassID;
                allClassesGrid.Rows[rowIndex].Cells[1].Value = c.getClassName();
                allClassesGrid.Rows[rowIndex].Cells[2].Value = c.getClassDescription();
                allClassesGrid.Rows[rowIndex].Cells[3].Value = c.getMaxParticipants();
                allClassesGrid.Rows[rowIndex].Cells[4].Value = c.getTrainerID();
                allClassesGrid.Rows[rowIndex].Cells[5].Value = c.getDate().ToString("yyyy-MM-dd");       
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AdminHomePage adminHomePage = new AdminHomePage();
            adminHomePage.Show();
            this.Hide();
        }
    }
}
