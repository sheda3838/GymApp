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
    public partial class AdminViewAllMembers : Form
    {

        public AdminViewAllMembers()
        {
            InitializeComponent();
        }

        private void ViewAllMembers_Load(object sender, EventArgs e)
        {
            InitializeGrid();

            List<Member> members = MemberManager.GetAllMembers();

            foreach (Member member in members)
            {
                int rowIndex = AllMembersGrid.Rows.Add();
                AllMembersGrid.Rows[rowIndex].Cells[0].Value = member.MemberID;
                AllMembersGrid.Rows[rowIndex].Cells[1].Value = member.getName();
                AllMembersGrid.Rows[rowIndex].Cells[2].Value = member.getEmail();
                AllMembersGrid.Rows[rowIndex].Cells[3].Value = member.getAge();
                AllMembersGrid.Rows[rowIndex].Cells[4].Value = member.getPhoneNumber();
                AllMembersGrid.Rows[rowIndex].Cells[5].Value = member.getUserName();
                AllMembersGrid.Rows[rowIndex].Cells[6].Value = member.getMembershipType();
                AllMembersGrid.Rows[rowIndex].Cells[7].Value = member.getStartDate().ToString("yyyy-MM-dd");
            }
        }

        private void InitializeGrid()
        {
            AllMembersGrid.Columns.Add("MemberID", "Member ID");
            AllMembersGrid.Columns.Add("Name", "Name");
            AllMembersGrid.Columns.Add("Email", "Email");
            AllMembersGrid.Columns.Add("Age", "Age");
            AllMembersGrid.Columns.Add("PhoneNumber", "Phone Number");
            AllMembersGrid.Columns.Add("Username", "Username");
            AllMembersGrid.Columns.Add("MembershipType", "Membership Type");
            AllMembersGrid.Columns.Add("StartDate", "Start Date");

            // Add a button column for actions
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "DetailsButton";
            buttonColumn.HeaderText = "Actions";
            buttonColumn.Text = "View Member";
            buttonColumn.UseColumnTextForButtonValue = true; // Set the button text

            AllMembersGrid.Columns.Add(buttonColumn);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            AdminHomePage adminHomePage = new AdminHomePage();
            adminHomePage.Show();
            this.Hide();
        }

        private void AllMembersGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AllMembersGrid.Columns["DetailsButton"].Index && e.RowIndex >= 0)
            {
                // Retrieve ClassID from the clicked row
                Member.LoggedInMemberUserName = (AllMembersGrid.Rows[e.RowIndex].Cells["Username"].Value).ToString();
                Member.LoggedInMemberID = Convert.ToInt32(AllMembersGrid.Rows[e.RowIndex].Cells["MemberID"].Value);


                AdminViewOneMember adminViewOneMember = new AdminViewOneMember();
                adminViewOneMember.Show();
                this.Hide();
            }
        }
    }
}
