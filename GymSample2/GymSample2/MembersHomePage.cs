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
    public partial class MembersHomePage : Form
    {
        public MembersHomePage()
        {
            InitializeComponent();
        }

        private void MembersHomePage_Load(object sender, EventArgs e)
        {

        }


        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MemberJoinClassesForm memberClassesForm = new MemberJoinClassesForm();
            memberClassesForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            List<Attendance> attendanceHistory = new Attendance().GetMemberAttendance(Member.LoggedInMemberID);

            if (attendanceHistory.Count > 0)
            {
                MemberAttendanceForm memberAttendanceForm = new MemberAttendanceForm();
                memberAttendanceForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No attendance to display!!","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            List<Classes> classesList = Classes.GetClassesByUserID(Member.LoggedInMemberID);

            if (classesList.Count > 0)
            {
                MemberViewEnrolledClassesForm viewMemberClassForm = new MemberViewEnrolledClassesForm();
                viewMemberClassForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No enrolled classes", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            string userName = Member.LoggedInMemberUserName;

            Member memberDetails = Member.GetMemberDetails(userName);

            if (memberDetails != null)
            {
                MemberViewProfileForm viewMemberForm = new MemberViewProfileForm();
                viewMemberForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("An Error Occured!! User Details Nor Found!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MemberSigninForm memberssigninForm = new MemberSigninForm();
            memberssigninForm.Show();
            this.Hide();
        }
    }
}
