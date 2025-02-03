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
using static GymSample2.Trainer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GymSample2
{
    public partial class TrainerSignUpForm : Form
    {

        public TrainerSignUpForm()
        {
            InitializeComponent();
        }

        private void TrainerSignUpForm_Load(object sender, EventArgs e)
        {
            // Add Specializations  to ComboBox
            txttrainerspecialization.Items.Add("Strength");
            txttrainerspecialization.Items.Add("Pilates");
            txttrainerspecialization.Items.Add("Yoga");
            txttrainerspecialization.Items.Add("Cardio");
            txttrainerspecialization.Items.Add("Flexibility");      

            txttrainerspecialization.SelectedIndex = 0;  // This will set "Strength" as default
        }

        public bool validateTrainerInput(string name, string email, int age, string phoneNumber, string userName, string password, out string validationMessage)
        {
            validationMessage = string.Empty;

            //check if any field is empty
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber) || string.IsNullOrEmpty(userName)  || string.IsNullOrEmpty(password))
            {
                validationMessage = "All fields are required.";
                return false;
            } 

            //Email validation
            if (!ISValidemail(email))
            {
                validationMessage = "Please enter a valid email address.";
                return false;
            }


            //validates the age
            if (age < 21 || age > 100)
            {
                validationMessage = "Age must be between 21 and 100.";
                return false;
            }

            //checks the phone number
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


            return true;
        }

        private bool ISValidemail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsUsernameUnique(string userName)
        {
            //Check username already exist
            using (var connection = new DatabaseHelper().Connect())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Trainers WHERE UserName = @UserName";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count == 0;  // Return true if username is unique
                }
            }
        }


        private void signupbtn_Click(object sender, EventArgs e)
        {
            //Get inputs from etxtboxes
            string name = txtname.Text;
            string email = txtemail.Text;
            int age;
            bool isAgeValid = int.TryParse(txtage.Text, out age);
            string phoneNumber = txtphonenumber.Text;
            string userName = txtusername.Text;
            string password = txtpassword.Text;
            string trainerspecialization = txttrainerspecialization.SelectedItem.ToString();

            //Vaidate the inputs
            string validationMessage;
            if (validateTrainerInput(name, email, age, phoneNumber, userName, password, out validationMessage))
            {
                // Call the createtrainer method to insert into the database

                int newTraiinerID = Trainer.CreateTrainer(name, email, age, phoneNumber, userName,password, trainerspecialization);

                MessageBox.Show($"Trainer created successfully! Your Trainer ID is {newTraiinerID}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TrainerSignInForm trainerSignInForm = new TrainerSignInForm();
                trainerSignInForm.Show();
                this.Hide();

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
            txttrainerspecialization.SelectedIndex = 0;

            txtname.Focus();
        }

        private void showpasswordbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (showpasswordbtn.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
            }
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            ClearFormInputs();
        }

        private void signinformchange_Click(object sender, EventArgs e)
        {
            TrainerSignInForm trainersigninform = new TrainerSignInForm();
            trainersigninform.Show();
            this.Hide();
        }

        private void gobackbtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearFormInputs();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            TrainerSignInForm trainerSignInForm = new TrainerSignInForm();
            trainerSignInForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TrainerSignInForm trainerSignInForm1 = new TrainerSignInForm();
            trainerSignInForm1.Show();
            this.Hide();
        }
    }
}
