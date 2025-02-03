using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    internal class Attendance
    {
        //Attributes
        public int AttendanceID;
        private int MemberID;
        private int ClassID;
        private int UpdatedTrainerID;
        private string AttendanceStatus;

        //Constructor
        public Attendance(int memberID, int classID, int updatedTrainerID, string attendanceStatus)
        {
            MemberID = memberID;
            ClassID = classID;
            UpdatedTrainerID = updatedTrainerID;
            AttendanceStatus = attendanceStatus;
        }

        public Attendance()
        {

        }

        //Setters
        public void setMemberID(int memberID)
        {
            MemberID = memberID;
        }

        public void setClassID(int classID)
        {
            ClassID = classID;
        }

        public void setUpdatedTrainerID(int updatedTrainerID)
        {
            UpdatedTrainerID = updatedTrainerID;
        }

        public void setAttendanceStatus(string attendancestatus)
        {
            AttendanceStatus = attendancestatus;
        }

        //Getters
        public int GetAttendanceID()
        {
            return AttendanceID;
        }

        public int GetMemberID()
        {
            return MemberID;
        }

        public int GetCLassID()
        {
            return ClassID;
        }

        public int GetUpdatedTrainerID()
        {
            return UpdatedTrainerID;
        }

        public string GetAttendanceStatus()
        {
            return AttendanceStatus;
        }
    }
}
