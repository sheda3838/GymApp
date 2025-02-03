using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
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


        public Member()
        {

        }

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

        public override string DisplayInfo()
        {
            return getName() + getEmail() + getAge() + getPhoneNumber() + getUserName() + getPassword() + getMembershipType() + getStartDate();
        }
    }
}
