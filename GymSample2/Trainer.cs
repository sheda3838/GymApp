using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public Trainer()
        {

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

        public override string DisplayInfo()
        {
            return getName() + getEmail() + getAge() + getPhoneNumber() + getUserName() + getPassword() + getTrainerSpecialization();       
        }
    }
}
