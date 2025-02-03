using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GymSample2.Member;

namespace GymSample2
{
    public partial class MemberSignUpForm : Form
    {

        public MemberSignUpForm()
        {
            InitializeComponent();
        }

        private void MemberSignUp_Load(object sender, EventArgs e)
        {
            // Add Membership Types to ComboBox
            txtmembershiptype.Items.Add("Standard");
            txtmembershiptype.Items.Add("Premium");
            txtmembershiptype.Items.Add("VIP");

            txtmembershiptype.SelectedIndex = 0;  // This will set "Standard" as default
        }

        public bool ValidateMemberInput(string name, string email, int age, string phoneNumber, string userName, string password, DateTime startDate, out string validationMessage)
        {
            validationMessage = string.Empty;

            // Check if any field is empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                validationMessage = "All fields are required.";
                return false;
            }

            // Check if email is valid
            if (!IsValidEmail(email))
            {
                validationMessage = "Please enter a valid email address.";
                return false;
            }

            if (age < 15 || age > 100)
            {
                validationMessage = "Age must be between 16 and 100.";
                return false;
            }


            if (phoneNumber.Length != 10)
            {
                validationMessage = "Phone number must be 10 digits.";
                return false;
            }

            // Check if username is unique
            if (!IsUsernameUnique(userName))
            {
                validationMessage = "Username already exists. Please choose another.";
                return false;
            }

            if (startDate.Date <= DateTime.Now.Date)
            {
                validationMessage = "Start date cannot be today or in the past.";
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            // Simple email validation (you can improve this with regex)
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsUsernameUnique(string username)
        {
            // Check if username already exists in the database
            using (var connection = new DatabaseHelper().Connect())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Members WHERE UserName = @UserName";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0;  // Return true if username is unique
                }
            }
        }

        private void signupbtn_Click(object sender, EventArgs e)
        {
            // Retrieve input values from the textboxes and other controls
            string name = txtname.Text;
            string email = txtemail.Text;
            int age;
            bool isAgeValid = int.TryParse(txtage.Text, out age);
            string phoneNumber = txtphonenumber.Text; 
            string userName = txtusername.Text;
            string password = txtpassword.Text;
            string membershipType =  txtmembershiptype.SelectedItem.ToString();
            DateTime startDate = txtstartdate.Value;

            // Validate the input
            string validationMessage;
            if (ValidateMemberInput(name, email, age, phoneNumber, userName, password, startDate,  out validationMessage))
            {
                // Call the CreateMember method to insert into the database
                int newMemberId = MemberManager.CreateMember(name, email, age, phoneNumber, userName, password, membershipType, startDate);

                if (newMemberId > 0)
                {
                    MessageBox.Show($"Member created successfully! Your Member ID is {newMemberId}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ClearFormInputs();
                        
                    MemberSigninForm memberSigninForm = new MemberSigninForm();
                    memberSigninForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show($"failed to create member!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                // Show validation error message
                MessageBox.Show(validationMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFormInputs()
        {
            txtname.Clear();
            txtemail.Clear();
            txtage.Clear();
            txtphonenumber.Clear();
            txtusername.Clear();
            txtpassword.Clear();
            txtmembershiptype.SelectedIndex = 0;  
            txtstartdate.Value = DateTime.Now;  

            txtname.Focus();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MemberSigninForm memberSigninForm = new MemberSigninForm();
            memberSigninForm.Show();
            this.Hide();
        }

        private void showpasswordbtn_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkbox is checked
            if (showpasswordbtn.Checked)
            {
                // Show the password by setting the PasswordChar to '\0' (no character masking)
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                // Hide the password by setting the PasswordChar back to '*' (character masking)
                txtpassword.PasswordChar = '*';
            }
        }



        private void gobackbtn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFormInputs();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MemberSigninForm memberSigninForm = new MemberSigninForm();
            memberSigninForm.Show();
            this.Hide();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
