using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Project_management_System.Util
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection(string fileName)
        {
            string connectionString = DBPropertyUtil.GetConnectionString(fileName);

            return new SqlConnection(connectionString);
        }
    }
}
