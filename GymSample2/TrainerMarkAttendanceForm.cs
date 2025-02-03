    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace GymSample2
    {
    public partial class TrainerMarkAttendanceForm : Form
    {
        private int currentClassID;

        public TrainerMarkAttendanceForm(int classID)
        {
            InitializeComponent();
            currentClassID = classID;
        }

        private void MarkAttendanceForm_Load(object sender, EventArgs e)
        {
            InitializeGrid();


            List<int> memberIDs = ClassManager.GetMembersInClass(currentClassID);

            foreach (int memberID in memberIDs)
            {
                // Add a new row for each member
                int rowIndex = AttendanceList.Rows.Add();
                AttendanceList.Rows[rowIndex].Cells[0].Value = memberID; // Add MemberID in first column
            }
        }

        private void InitializeGrid()
        {
            // Add columns to DataGridView
            AttendanceList.Columns.Add("MemberID", "Member ID");

            // Add checkboxes for Present and Absent columns
            DataGridViewCheckBoxColumn joinedColoumn = new DataGridViewCheckBoxColumn();
            joinedColoumn.HeaderText = "Attended";
            AttendanceList.Columns.Add(joinedColoumn);

        }

        private void AttendanceList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void aveattendancebtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in AttendanceList.Rows)
            {
                int memberID = Convert.ToInt32(row.Cells[0].Value);
                string attendanceStatus = "Absent"; // Default status is absent

                // If Attended checkbox is checked, mark as Present
                if (Convert.ToBoolean(row.Cells[1].Value))
                {
                    attendanceStatus = "Present";
                }

                AttendanceManager.CreatAttendance(memberID, currentClassID, attendanceStatus, Trainer.LoggedInTrainerID);
            }

            MessageBox.Show("Attendance saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            TrainerViewCreatedClassForm viewTrainerClassForm = new TrainerViewCreatedClassForm();
            viewTrainerClassForm.Show();
            this.Hide();
        }
    }
 }
