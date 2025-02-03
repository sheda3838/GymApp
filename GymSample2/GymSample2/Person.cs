using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSample2
{
    internal class Person
    {
        //Attributes
        protected string Name;
        protected string Email;
        protected int Age;
        protected string PhoneNumber;
        protected string UserName;
        protected string Password;

        //Constructor
        public Person(string name, string email, int age, string phoneNumber, string userName, string password)
        {
            Name = name;
            Email = email;
            Age = age;
            PhoneNumber = phoneNumber;
            UserName = userName;
            Password = password;
        }

        //Setters
        public void setName(string name)
        {
            Name = name;
        }

        public void setEmail(string email)
        {
            Email = email;
        }

        public void setAge(int age)
        {
            Age = age;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void setUserName(string username)
        {
            UserName = username;
        }

        public void setPassword(string password)
        {
            Password = password;
        }

        //Getters
        public string getName()
        {
            return Name;
        }

        public string getEmail()
        {
            return Email;
        }

        public int getAge()
        {
            return Age;
        }

        public string getPhoneNumber()
        {
            return PhoneNumber;
        }

        public string getUserName()
        {
            return UserName;
        }

        public string getPassword()
        {
            return Password;
        }
    }

}
