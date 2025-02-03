using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymSample2
{
    internal class Trainer : Person
    {
        //To save the the trainer username
        public static string LoggedInTrainerUserName;
        public static int LoggedInTrainerID;

        //Attributes
        public int TrainerID;
        private string TrainerSpecialization;
        private double Salary;

        public Trainer(string name, string email, int age, string phoneNumber, string userName, string password, string trainerSpecialization) : base(name, email, age, phoneNumber, userName, password)
        {
            TrainerSpecialization = trainerSpecialization;
            Salary = CalculateSalary();
        }


        //Method to calculate salary
        public double CalculateSalary()
        {
            // Example: Salary based on specialization 
            switch (TrainerSpecialization)
            {
                case "Strength":
                    return 3000;
                case "Cardio":
                    return 2500;
                case "Flexibility":
                    return 2800;
                case "Yoga":
                    return 3200;
                case "Pilates":
                    return 3300;
                default:
                    return 0;
            }
        }

        //Setters
        public void setTrainerSpecialization(string trainerSpecialization)
        {
            TrainerSpecialization = trainerSpecialization;
        }

        public void setSalary(double salary)
        {
            Salary = salary; //Have implemented to pass the salary in to controller 
        }

        //Getters
        public string getTrainerSpecialization()
        {
            return TrainerSpecialization;
        }

        public double getSalary()
        {
            return Salary;
        }


        //Method to create new Trainer (sign up function)
        public static int CreateTrainer(string name, string email, int age, string phoneNumber, string userName, string password, string trainerspecialization)
        {
            Trainer newTrainer = new Trainer(name, email, age, phoneNumber, userName, password, trainerspecialization);

            int newTrainerID = InsertTrainer(newTrainer);

            return newTrainerID;
        }

        public static int InsertTrainer(Trainer trainer)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    // Updated query to return the inserted trainer's ID
                    string query = @"
            INSERT INTO Trainers (Name, Email, Age, PhoneNumber, UserName, Password, Specialization, Salary) 
            OUTPUT INSERTED.TrainerID
            VALUES (@Name, @Email, @Age, @PhoneNumber, @UserName, @Password, @Specialization, @Salary)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", trainer.getName());
                        cmd.Parameters.AddWithValue("@Email", trainer.getEmail());
                        cmd.Parameters.AddWithValue("@Age", trainer.getAge());
                        cmd.Parameters.AddWithValue("@PhoneNumber", trainer.getPhoneNumber());
                        cmd.Parameters.AddWithValue("@UserName", trainer.getUserName());
                        cmd.Parameters.AddWithValue("@Password", trainer.getPassword());
                        cmd.Parameters.AddWithValue("@Specialization", trainer.getTrainerSpecialization().ToString());
                        cmd.Parameters.AddWithValue("@Salary", trainer.getSalary());

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
        //Methods to search for a trainer (sign in function)
        public static bool searchTrainer(string username, string password)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT TrainerID FROM Trainers WHERE UserName = @UserName AND Password = @Password";
                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // If found, store the TrainerID in the static variable (useful when creating class)
                            LoggedInTrainerID = Convert.ToInt32(result);
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




        //methods to read information (view profile function)
        public static Trainer GetTrainerDetails(string username)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT TrainerID, Name, Email, Age, PhoneNumber, UserName, Password, Specialization, Salary FROM Trainers WHERE UserName = @UserName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("UserName", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int trainerID = Convert.ToInt32(reader["TrainerID"]);
                                double salary = Convert.ToDouble(reader["Salary"]); // Retrieve Salary


                                var trainer = new Trainer(
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    Convert.ToInt32(reader["Age"]),
                                    reader["PhoneNumber"].ToString(),
                                    reader["UserName"].ToString(),
                                    reader["Password"].ToString(),
                                    reader["Specialization"].ToString()
                                );

                                trainer.TrainerID = trainerID;
                                trainer.setSalary(salary);

                                return trainer;
                            }
                            else
                            {
                                return null;
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


        //Method to update trainer information
        public static bool UpdateTrainer(string username, string name, string email, int age, string phoneNumber, string specialization)
        {

            try
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
                        cmd.Parameters.AddWithValue("@UserName", username);

                        int rowsAffected = cmd.ExecuteNonQuery();
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



        //Method to delete trainer profile
        public static bool DeleteTrainer(string username)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "DELETE FROM Trainers WHERE UserName = @UserName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);

                        int rowsaffected = Convert.ToInt32(cmd.ExecuteNonQuery());

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

        //method to get all trainers (admin)
        public static List<Trainer> GetAllTrainers()
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
