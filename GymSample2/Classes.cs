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
    }
}

