using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_management_System.Entity
{
    public class EntityTask
    {
        public int Task_Id { get; set; }
        public string TaskName { get; set; }
        public int Project_Id { get; set; }
        public int Employee_Id { get; set; }
        public string Status { get; set; }

        public EntityTask()
        {

        }
        public EntityTask(int Task_Id, string TaskName, int Project_Id, int Employee_Id,string Status)
        {
            this.Task_Id = Task_Id;
            this.TaskName = TaskName;
            this.Project_Id = Project_Id;
            this.Employee_Id = Employee_Id;
            this.Status = Status;
        }


    }
}
