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

        //method to mark attendance
        public static void MarkAttendance(int memberID, int classID, string attendanceStatus, int updatedTrainerID)
        {
            try
            {
                string existingAttendance = GetAttendance(memberID, classID);

                if (existingAttendance == null) //checks whether attendance marked earlier if not execute query
                {
                    string query = "INSERT INTO Attendance (MemberID, ClassID, AttendanceStatus, UpdatedByTrainerID) " +
                                   "VALUES (@MemberID, @ClassID, @AttendanceStatus, @UpdatedByTrainerID)";

                    using (SqlConnection conn = new DatabaseHelper().Connect())
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MemberID", memberID);
                        cmd.Parameters.AddWithValue("@ClassID", classID);
                        cmd.Parameters.AddWithValue("@AttendanceStatus", attendanceStatus);
                        cmd.Parameters.AddWithValue("@UpdatedByTrainerID", updatedTrainerID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    // if it is marked earlier update attendance by changing the status
                    UpdateAttendance(memberID, classID, attendanceStatus, updatedTrainerID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //method to get attendance
        public static string GetAttendance(int memberID, int classID)
        {
            try
            {
                string attendanceStatus = null;
                string query = "SELECT AttendanceStatus FROM Attendance WHERE MemberID = @MemberID AND ClassID = @ClassID";

                // Database connection and query execution
                using (SqlConnection conn = new DatabaseHelper().Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    cmd.Parameters.AddWithValue("@ClassID", classID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        attendanceStatus = reader["AttendanceStatus"].ToString();
                    }
                }

                return attendanceStatus;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        // method to update attendance
        public static void UpdateAttendance(int memberID, int classID, string attendanceStatus, int updatedTrainerID)
        {
            try
            {
                string query = "UPDATE Attendance SET AttendanceStatus = @AttendanceStatus " +
                           "WHERE MemberID = @MemberID AND ClassID = @ClassID";

                // Database connection and query execution
                using (SqlConnection conn = new DatabaseHelper().Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@AttendanceStatus", attendanceStatus);
                    cmd.Parameters.AddWithValue("@UpdatedByTrainerID", updatedTrainerID);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);
                    cmd.Parameters.AddWithValue("@ClassID", classID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //method to retrieve attendance recors using memberid 
        public List<Attendance> GetMemberAttendance(int memberID)
        {
            try
            {
                List<Attendance> attendanceRecords = new List<Attendance>();

                string query = "SELECT ClassID, AttendanceStatus, UpdatedByTrainerID FROM Attendance WHERE MemberID = @MemberID";

                using (SqlConnection conn = new DatabaseHelper().Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Attendance record = new Attendance(
                            MemberID = memberID,
                            ClassID = reader.GetInt32(reader.GetOrdinal("ClassID")),
                            UpdatedTrainerID = reader.GetInt32(reader.GetOrdinal("UpdatedByTrainerID")),
                            AttendanceStatus = reader.GetString(reader.GetOrdinal("AttendanceStatus"))
                        );

                        attendanceRecords.Add(record);
                    }
                }

                return attendanceRecords;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<Attendance> GetAllAttendances()
        {
            try
            {
                List<Attendance> attendances = new List<Attendance>();

                using (var conn = new DatabaseHelper().Connect())
                {
                    conn.Open();

                    string query = "SELECT * FROM Attendance";

                    using (var command = new SqlCommand(query, conn))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Attendance record = new Attendance(
                                reader.GetInt32(reader.GetOrdinal("MemberID")),
                                reader.GetInt32(reader.GetOrdinal("ClassID")),
                                reader.GetInt32(reader.GetOrdinal("UpdatedByTrainerID")),
                                reader.GetString(reader.GetOrdinal("AttendanceStatus"))
                            );
                                {
                                    record.AttendanceID = reader.GetInt32(reader.GetOrdinal("AttendanceID"));
                                }

                                attendances.Add(record);
                            }
                        }
                    }
                }
                return attendances;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
