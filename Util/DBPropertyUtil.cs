using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_management_System.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string filename)
        {
            string line = File.ReadAllText(filename);

            return line.Substring("connectionString=".Length).Trim();
        }
    }
}
