using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    internal class Classes
    {
        //Attributes
        public int ClassID;
        private string ClassName;
        private string Description;
        private int TrainerID;
        private DateTime Date;
        private int MaxParticipants;
        public int CurrentParticipants;
        //Constructor
        public Classes(string className, string description, int trainerID, DateTime date, int maxParticipants)
        {
            ClassName = className;
            Description = description;
            TrainerID = trainerID;
            Date = date;
            MaxParticipants = maxParticipants;
        }

        //Setters
        public void setClassName(string className)
        {
            ClassName = className;
        }

        public void setDescription(string description)
        {
            Description = description;
        }

        public void setTrainerID(int trainerID)
        {
            TrainerID = trainerID;
        }


        public void setDate(DateTime date)
        {
            Date = date;
        }

        public void setMaxParticipants(int maxParticipants)
        {
            MaxParticipants = maxParticipants;
        }


        //Getters
        public string getClassName()
        {
            return ClassName;
        }

        public string getClassDescription()
        {
            return Description;
        }

        public int getTrainerID()
        {
            return TrainerID;
        }

        public DateTime getDate()
        {
            return Date;
        }

        public int getMaxParticipants()
        {
            return MaxParticipants;
        }

        public int getCurrentParticipants()
        {
            return CurrentParticipants;
        }




        // Method to create a new class (create class in trainer)
        public static bool CreateClass(string className, string description, int trainerID, DateTime date, int maxParticipants)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"
                INSERT INTO Classes (ClassName, Description, TrainerID, Date, MaxParticipants)
                VALUES (@ClassName, @Description, @TrainerID, @Date, @MaxParticipants)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassName", className);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@TrainerID", trainerID);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@MaxParticipants", maxParticipants);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // If rows were affected, the class creation was successful
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        //  method to fetch classes by MemberID (view enrolled classes for members) 
        public static List<Classes> GetClassesByUserID(int userID)
        {
            try
            {
                List<Classes> classesList = new List<Classes>();

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"SELECT Classes.ClassID, Classes.ClassName, Classes.Description, Classes.Date, Classes.MaxParticipants, Classes.TrainerID, 
                               (SELECT COUNT(*) FROM ClassParticipants WHERE ClassID = Classes.ClassID) AS CurrentParticipants
                        FROM Classes
                        INNER JOIN ClassParticipants ON Classes.ClassID = ClassParticipants.ClassID
                        WHERE ClassParticipants.MemberID = @MemberID";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", userID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())  //The while (reader.Read()) loop iterates through each row in the result set.
                            {
                                Classes userclass = new Classes(
                                    reader["ClassName"].ToString(),
                                    reader["Description"].ToString(),
                                    Convert.ToInt32(reader["TrainerID"]),
                                    Convert.ToDateTime(reader["Date"]),
                                    Convert.ToInt32(reader["MaxParticipants"])
                                )
                                {
                                    ClassID = Convert.ToInt32(reader["ClassID"]),
                                    CurrentParticipants = Convert.ToInt32(reader["CurrentParticipants"]) // Set the current participants

                                };

                                classesList.Add(userclass);
                            }
                        }
                    }
                }

                return classesList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //  method to fetch classes by TrainerID (view created classes for trainer, also used in member to get favourite trainer classes) 
        public static List<Classes> GetClassesByTrainerID(int trainerID)
        {
            try
            {
                List<Classes> classesList = new List<Classes>();

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"SELECT ClassID, ClassName, Description, Date, MaxParticipants, TrainerID ,
                     (SELECT COUNT(*) FROM ClassParticipants WHERE ClassID = Classes.ClassID) AS CurrentParticipants
                     FROM Classes
                     WHERE TrainerID = @TrainerID";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TrainerID", trainerID);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())  //The while (reader.Read()) loop iterates through each row in the result set.
                            {
                                Classes trainerClass = new Classes(
                                    reader["ClassName"].ToString(),
                                    reader["Description"].ToString(),
                                    Convert.ToInt32(reader["TrainerID"]),
                                    Convert.ToDateTime(reader["Date"]),
                                    Convert.ToInt32(reader["MaxParticipants"])
                                )
                                {
                                    ClassID = Convert.ToInt32(reader["ClassID"]),
                                    CurrentParticipants = Convert.ToInt32(reader["CurrentParticipants"]) // Set the current participants

                                };

                                classesList.Add(trainerClass);
                            }
                        }
                    }
                }

                return classesList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //Method to fetch a single classes informtion (used in update class method)
        public static Classes GetClassById(int classId)
        {
            try
            {
                Classes classDetails = null;

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT ClassID, ClassName, Description, Date, MaxParticipants, TrainerID FROM Classes WHERE ClassID = @ClassID";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassID", classId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                classDetails = new Classes(
                                    reader["ClassName"].ToString(),
                                    reader["Description"].ToString(),
                                    Convert.ToInt32(reader["TrainerID"]),
                                    Convert.ToDateTime(reader["Date"]),
                                    Convert.ToInt32(reader["MaxParticipants"])
                                )
                                {
                                    ClassID = Convert.ToInt32(reader["ClassID"])
                                };
                            }
                        }
                    }
                }

                return classDetails; // Returns the class details if found, or null if not found
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        //method to update class by taking class id
        public static bool UpdateClass(int classId, string className, string description, DateTime date, int maxParticipants)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"
        UPDATE Classes
        SET ClassName = @ClassName, Description = @Description, Date = @Date, MaxParticipants = @MaxParticipants
        WHERE ClassID = @ClassID";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassName", className);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@MaxParticipants", maxParticipants);
                        cmd.Parameters.AddWithValue("@ClassID", classId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // If rows were affected, the class was updated successfully
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //method to delete class by class id
        public static bool DeleteClass(int classId)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "DELETE FROM Classes WHERE ClassID = @ClassID ";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassID", classId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // If rows were affected, the class was deleted successfully
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //  method to allow  member to join a class
        public static bool JoinClass(int classId, int memberId)
        {
            try{
                using(var connection = new DatabaseHelper().Connect())
            {
                    connection.Open();

                    // Check if the class exists
                    string checkClassQuery = "SELECT COUNT(*) FROM Classes WHERE ClassID = @ClassID";
                    using (var cmd = new SqlCommand(checkClassQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassID", classId);
                        int classCount = (int)cmd.ExecuteScalar();

                        // If class doesn't exist, show an error message
                        if (classCount == 0)
                        {
                            MessageBox.Show("The class ID you entered does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }

                    // Check if the member is already enrolled
                    if (IsMemberEnrolledInClass(classId, memberId))
                    {
                        MessageBox.Show("You are already enrolled in this class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }


                    // Check if there are available spots
                    string countQuery = "SELECT COUNT(*) FROM ClassParticipants WHERE ClassID = @ClassID";
                    using (var cmd = new SqlCommand(countQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassID", classId);
                        int currentParticipants = (int)cmd.ExecuteScalar();

                        string maxQuery = "SELECT MaxParticipants FROM Classes WHERE ClassID = @ClassID";
                        using (var cmdMax = new SqlCommand(maxQuery, connection))
                        {
                            cmdMax.Parameters.AddWithValue("@ClassID", classId);
                            int maxParticipants = (int)cmdMax.ExecuteScalar();

                            if (currentParticipants >= maxParticipants)
                            {
                                MessageBox.Show("This class is full. Cannot join.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            }
                        }
                    }

                    // Add the member to the class
                    string query = "INSERT INTO ClassParticipants (ClassID, MemberID) VALUES (@ClassID, @MemberID)";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassID", classId);
                        cmd.Parameters.AddWithValue("@MemberID", memberId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("You have successfully joined the class!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }




        //method to get all available classes (useful for member to view all classes and admin)
        public static List<Classes> GetAllAvailableClasses()
        {
            try
            {
                List<Classes> classesList = new List<Classes>();

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"SELECT ClassID, ClassName, Description, Date, MaxParticipants, TrainerID, 
                          (SELECT COUNT(*) FROM ClassParticipants WHERE ClassID = Classes.ClassID) AS CurrentParticipants
                          FROM Classes";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Classes availableclass = new Classes(
                                    reader["ClassName"].ToString(),
                                    reader["Description"].ToString(),
                                    Convert.ToInt32(reader["TrainerID"]),
                                    Convert.ToDateTime(reader["Date"]),
                                    Convert.ToInt32(reader["MaxParticipants"])
                                )
                                {
                                    ClassID = Convert.ToInt32(reader["ClassID"]),
                                    CurrentParticipants = Convert.ToInt32(reader["CurrentParticipants"]) // Set the current participants

                                };

                                classesList.Add(availableclass);
                            }
                        }
                    }
                }

                return classesList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        //Method to view all members in a class (trainer function)
        public static List<int> GetMembersInClass(int classId)
        {
            try
            {
                List<int> memberIDs = new List<int>();

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    // Query to fetch member IDs for the given class ID
                    string query = @"SELECT MemberID 
                         FROM ClassParticipants
                         WHERE ClassID = @ClassID";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ClassID", classId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Read and store the MemberID
                                memberIDs.Add(Convert.ToInt32(reader["MemberID"]));
                            }
                        }
                    }
                }

                return memberIDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        //method to remove member from a class (trainer and admin )
        public static bool DeleteMemberFromClass(int classID, int memberID)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "DELETE FROM ClassParticipants WHERE ClassID = @ClassID AND MemberID = @MemberID ";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassID", classID);
                        command.Parameters.AddWithValue("@MemberID", memberID);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        //method to check trainer has already created a class on the relevant date
        public static bool IsTrainerAvailableOnDate(int trainerID, DateTime date)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"
            SELECT COUNT(*) 
            FROM Classes 
            WHERE TrainerID = @TrainerID AND Date = @Date";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("TrainerID", trainerID);
                        command.Parameters.AddWithValue("@Date", date.Date);

                        int count = (int)command.ExecuteScalar();
                        return count == 0; // True if no class exists for the trainer on the date
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //method ti check has user already enrolled in the class (used in joing the class and displaying avaialbel classes)
        public static bool IsMemberEnrolledInClass(int memberID, int classID)
        {
            try
            {
                bool isEnrolled = false;

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM ClassParticipants WHERE MemberID = @MemberID AND ClassID = @ClassID";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", memberID);
                        cmd.Parameters.AddWithValue("@ClassID", classID);

                        int count = (int)cmd.ExecuteScalar();
                        isEnrolled = count > 0;
                    }
                }

                return isEnrolled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}

