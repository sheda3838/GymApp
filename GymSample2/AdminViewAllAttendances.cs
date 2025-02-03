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
    public partial class AdminViewAllAttendances : Form
    {
        public AdminViewAllAttendances()
        {
            InitializeComponent();
        }

        private void ViewAllAttendances_Load(object sender, EventArgs e)
        {
            InitializeGrid();

            List<Attendance> attendances = AttendanceManager.GetAllAttendances();

            foreach (Attendance attendance in attendances)
            {
                int rowIndex = AllAttendnaceGrid.Rows.Add();
                AllAttendnaceGrid.Rows[rowIndex].Cells[0].Value = attendance.AttendanceID;
                AllAttendnaceGrid.Rows[rowIndex].Cells[1].Value = attendance.GetMemberID();
                AllAttendnaceGrid.Rows[rowIndex].Cells[2].Value = attendance.GetCLassID();
                AllAttendnaceGrid.Rows[rowIndex].Cells[3].Value = attendance.GetUpdatedTrainerID();
                AllAttendnaceGrid.Rows[rowIndex].Cells[4].Value = attendance.GetAttendanceStatus();
            }
        }

        private void InitializeGrid()
        {
            AllAttendnaceGrid.Columns.Add("AttendanceID", "Attendance ID");
            AllAttendnaceGrid.Columns.Add("MemberID", "Member ID");
            AllAttendnaceGrid.Columns.Add("ClassID", "Class ID");
            AllAttendnaceGrid.Columns.Add("UpdatedTrainerID", "Updated Trainer ID");
            AllAttendnaceGrid.Columns.Add("AttendanceStatus", "Attendance Status");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AdminHomePage adminHomePage = new AdminHomePage();
            adminHomePage.Show();
            this.Hide();
        }
    }
}
