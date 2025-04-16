using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_management_System.MyExceptions
{
    public class EmployeeNotFoundException:Exception
    {
        public EmployeeNotFoundException(String message) : base(message)
        {

        }
    }
}
