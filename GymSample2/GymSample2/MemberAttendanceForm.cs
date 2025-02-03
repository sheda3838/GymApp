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
    public partial class MemberAttendanceForm : Form
    {
        public MemberAttendanceForm()
        {
            InitializeComponent();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {
            MembersHomePage membersHomePage = new MembersHomePage();
            membersHomePage.Show();
            this.Hide();                
        }

        private void MemberAttendanceForm_Load(object sender, EventArgs e)
        {
            InitializeGrid();
            int memberID = Member.LoggedInMemberID;  

            List<Attendance> attendanceHistory = new Attendance().GetMemberAttendance(memberID);

            // Clear the existing rows before adding new data
            AttendanceList.Rows.Clear();

            // Add rows to the DataGridView
            foreach (Attendance record in attendanceHistory)
            {
                int rowIndex = AttendanceList.Rows.Add();  
                AttendanceList.Rows[rowIndex].Cells[0].Value = record.GetCLassID();  
                AttendanceList.Rows[rowIndex].Cells[1].Value = record.GetAttendanceStatus(); 
                AttendanceList.Rows[rowIndex].Cells[2].Value = record.GetUpdatedTrainerID();  
            }
        }

        private void InitializeGrid()
        {
            // Add columns to DataGridView
            AttendanceList.Columns.Add("ClassID", "Class ID");
            AttendanceList.Columns.Add("AttendanceStatus", "Attendance Status");
            AttendanceList.Columns.Add("TrainerID", "Trainer ID");
        }

        private void AttendanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MembersHomePage membersHomePage = new MembersHomePage();
            membersHomePage.Show();
            this.Hide();
        }
    }
}
