using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymSample2
{
    internal class Member : Person
    {
        //To save the logged in members username 
        public static string LoggedInMemberUserName;
        public static int LoggedInMemberID;

        //Attributes
        public  int MemberID;
        private string membershipType;
        private DateTime StartDate;

        //Constructor

        public Member(string name, string email, int age, string phoneNumber, string userName, string password, string membershipType, DateTime startDate) : base(name, email, age, phoneNumber, userName, password)
        {
            this.membershipType = membershipType;
            StartDate = startDate;
        }


        //ALlowing user to select a type 


        //Setters
        public void setMembershipType(string membershipType)
        {
            this.membershipType = membershipType;
        }

        public void setStartDate(DateTime startDate)
        {
            StartDate = startDate;
        }

        //Getters
        public string getMembershipType()
        {
            return membershipType;
        }

        public DateTime getStartDate()
        {
            return StartDate;
        }


        //Method to create new member (sign up function)
        public static int CreateMember(string name, string email, int age, string phoneNumber, string userName, string password, string membershipType, DateTime startDate)
        {
            Member newMember = new Member(name, email, age, phoneNumber, userName, password, membershipType, startDate);

            int newMemberId = InsertMember(newMember);

            return newMemberId; // Return the ID
        }

        public static int InsertMember(Member member)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    // Updated query to return the inserted member's ID
                    string query = @"
            INSERT INTO Members (Name, Email, Age, PhoneNumber, UserName, Password, MembershipType, StartDate) 
            OUTPUT INSERTED.MemberID
            VALUES (@Name, @Email, @Age, @PhoneNumber, @UserName, @Password, @MembershipType, @StartDate)";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", member.getName());
                        cmd.Parameters.AddWithValue("@Email", member.getEmail());
                        cmd.Parameters.AddWithValue("@Age", member.getAge());
                        cmd.Parameters.AddWithValue("@PhoneNumber", member.getPhoneNumber());
                        cmd.Parameters.AddWithValue("@UserName", member.getUserName());
                        cmd.Parameters.AddWithValue("@Password", member.getPassword());
                        cmd.Parameters.AddWithValue("@MembershipType", member.getMembershipType());
                        cmd.Parameters.AddWithValue("@StartDate", member.getStartDate().ToString("yyyy-MM-dd"));

                        // Execute the query and return the newly inserted ID
                        int newMemberId = (int)cmd.ExecuteScalar();
                        return newMemberId;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }





        //Method to search for a member (sign in function)
        public static bool SearchMember(string userName, string password)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT MemberID FROM Members WHERE UserName = @UserName AND Password = @Password";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@Password", password);

                        // Execute the query and get the MemberID
                        var result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            // If found, store the MemberID in the static variable
                            LoggedInMemberID = Convert.ToInt32(result);
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



        //Method to get member details (view member function)
        public static Member GetMemberDetails(string username)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT MemberID, Name, Email, Age, PhoneNumber, UserName, Password, MembershipType, StartDate FROM Members WHERE UserName = @UserName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int memberId = Convert.ToInt32(reader["MemberID"]);

                                // Create a Member object to store the details by passing necessary parameters
                                var member = new Member(
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    Convert.ToInt32(reader["Age"]),
                                    reader["PhoneNumber"].ToString(),
                                    reader["UserName"].ToString(),
                                    reader["Password"].ToString(),
                                    reader["MembershipType"].ToString(),
                                    Convert.ToDateTime(reader["StartDate"])
                                );

                                member.MemberID = memberId;


                                return member;
                            }
                            else
                            {
                                return null; // Member not found
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


        //Method to update memebr
        public static bool UpdateMember(string username, string name, string email, int age, string phoneNumber, string membershipType)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = @"
            UPDATE Members 
            SET Name = @Name, 
                Email = @Email, 
                Age = @Age, 
                PhoneNumber = @PhoneNumber, 
                MembershipType = @MembershipType 
            WHERE UserName = @UserName"; // Ensure the parameter @UserName is included

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Age", age);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@MembershipType", membershipType);
                        cmd.Parameters.AddWithValue("@UserName", username); // Ensure this is being added

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // If rows were affected, the update was successful
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }



        //Methods to Delete Member
        public static bool DeleteMember(string username)
        {
            try
            {
                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "DELETE FROM Members WHERE UserName = @UserName";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0; // If rows were affected, the deletion was successful
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        //method to get all members list (admin)
        public static List<Member> GetAllMembers()
        {
            try
            {
                List<Member> members = new List<Member>();

                using (var connection = new DatabaseHelper().Connect())
                {
                    connection.Open();

                    string query = "SELECT * FROM Members";

                    using (var cmd = new SqlCommand(query, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Member member = new Member(
                                    reader["Name"].ToString(),
                                    reader["Email"].ToString(),
                                    Convert.ToInt32(reader["Age"]),
                                    reader["PhoneNumber"].ToString(),
                                    reader["UserName"].ToString(),
                                    reader["Password"].ToString(),
                                    reader["MembershipType"].ToString(),
                                    Convert.ToDateTime(reader["StartDate"])
                                    );
                                {
                                    member.MemberID = Convert.ToInt32(reader["MemberID"]);
                                };

                                members.Add(member);
                            }
                        }
                    }
                }
                return members;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
