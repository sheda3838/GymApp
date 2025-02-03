using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    internal class TrainerManager 
    {
        //Methods to search for a trainer (sign in function)
        public static bool ValidateTrainer(string userName, string password)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT TrainerID FROM Trainers WHERE UserName = @UserName AND Password = @Password";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // If found, store the TrainerID in the static variable (useful when creating class)
                            Trainer.LoggedInTrainerID = Convert.ToInt32(result);
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static int CreateTrainer(string name, string email, int age, string phoneNumber, string userName, string password, string specialization, double salary)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Trainers (Name, Email, Age, PhoneNumber, UserName, Password, Specialization, Salary) 
                        OUTPUT INSERTED.TrainerID
                        VALUES (@Name, @Email, @Age, @PhoneNumber, @UserName, @Password, @Specialization, @Salary)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);  // Access via instance method
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Specialization", specialization);
                        cmd.Parameters.AddWithValue("@Salary", salary);

                        int newTrainerID = (int)cmd.ExecuteScalar();
                        return newTrainerID;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static Person ViewTrainer(string userName)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT TrainerID, Name, Email, Age, PhoneNumber, UserName, Password, Specialization, Salary FROM Trainers WHERE UserName = @UserName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double salary = Convert.ToDouble(reader["Salary"]);

                                // Create the Trainer object
                                var trainer = new Trainer(
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    Convert.ToInt32(reader["Age"]),
                                    reader["PhoneNumber"].ToString(),
                                    reader["UserName"].ToString(),
                                    reader["Password"].ToString(),
                                    reader["Specialization"].ToString()
                                );


                                trainer.TrainerID = Convert.ToInt32(reader["TrainerID"]);
                                trainer.setSalary(salary);

                                return trainer;
                            }
                            else
                            {
                                return null;  // Return null if no trainer found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool UpdateTrainer(string userName, string name, string email, int age, string phoneNumber, string specialization)
        {
            using (var connection = new DatabaseHelper().Connect())
            {
                connection.Open();

                // @ is used to jump into new line to write query
                string query = @"
                UPDATE Trainers 
                SET Name = @Name, 
                    Email = @Email, 
                    Age = @Age, 
                    PhoneNumber = @PhoneNumber, 
                    Specialization = @Specialization 
                WHERE UserName = @UserName";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Specialization", specialization);
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }

            }
        }

        public static bool DeleteTrainer(string userName)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "DELETE FROM Trainers WHERE UserName = @UserName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);

                        int rowsaffected = cmd.ExecuteNonQuery();

                        return rowsaffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static List<Trainer> GetAllTariner()
        {
            try
            {
                List<Trainer> trainers = new List<Trainer>();

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT * FROM Trainers";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Trainer trainer = new Trainer(
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    Convert.ToInt32(reader["Age"]),
                                    reader["PhoneNumber"].ToString(),
                                    reader["UserName"].ToString(),
                                    reader["Password"].ToString(),
                                    reader["Specialization"].ToString());
                                {
                                    trainer.TrainerID = Convert.ToInt32(reader["TrainerID"]);
                                };

                                trainers.Add(trainer);
                            }


                        }
                    }
                }
                return trainers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
