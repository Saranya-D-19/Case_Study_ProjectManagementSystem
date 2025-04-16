using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_management_System.MyExceptions
{
    public class ProjectNotFoundException:Exception
    {
        public ProjectNotFoundException(String message):base(message)
        {

        }
    }
}
