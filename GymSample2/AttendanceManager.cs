using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    internal class AttendanceManager 
    {

        //method to retrieve attendance records using memberid  (useful for member) 
        public static List<Attendance> GetMemberAttendance(int memberID)
        {
            try
            {
                List<Attendance> attendanceRecords = new List<Attendance>();

                string query = "SELECT MemberID, ClassID, AttendanceStatus, UpdatedTrainerID FROM Attendance WHERE MemberID = @MemberID";

                using (SqlConnection conn = new DatabaseHelper().Connect())
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MemberID", memberID);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        int retrievedMemberID = reader.GetInt32(reader.GetOrdinal("MemberID"));
                        int classID = reader.GetInt32(reader.GetOrdinal("ClassID"));
                        int updatedByTrainerID = reader.GetInt32(reader.GetOrdinal("UpdatedTrainerID"));
                        string attendanceStatus = reader.GetString(reader.GetOrdinal("AttendanceStatus"));

                        Attendance attendanceRecord = new Attendance(retrievedMemberID, classID, updatedByTrainerID, attendanceStatus);

                        attendanceRecords.Add(attendanceRecord);
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


        //mark attendance ( for trainer )
        public static void CreatAttendance(int memberID, int classID, string attendanceStatus, int updatedTrainerID)
        {
            try
            {
                string existingAttendance = ViewAttendance(memberID, classID);

                if (existingAttendance == null) //checks whether attendance marked earlier if not execute query
                {
                    string query = "INSERT INTO Attendance (MemberID, ClassID, AttendanceStatus, UpdatedTrainerID) " +
                                   "VALUES (@MemberID, @ClassID, @AttendanceStatus, @UpdatedTrainerID)";

                    using (SqlConnection conn = new DatabaseHelper().Connect())
                    {
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@MemberID", memberID);
                        cmd.Parameters.AddWithValue("@ClassID", classID);
                        cmd.Parameters.AddWithValue("@AttendanceStatus", attendanceStatus);
                        cmd.Parameters.AddWithValue("@UpdatedTrainerID", updatedTrainerID);

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


        // get attendance of a member for a ceratin class
        public static string ViewAttendance(int memberID, int classID)
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


        //update attednance if marked
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
                    cmd.Parameters.AddWithValue("@UpdatedTrainerID", updatedTrainerID);
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


        //get all attendnace (for admin)
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
                                reader.GetInt32(reader.GetOrdinal("UpdatedTrainerID")),
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
