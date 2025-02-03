using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GymSample2
{
    internal class DatabaseHelper
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=GymDB;Trusted_Connection=True;";

        public SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }
    }
}
