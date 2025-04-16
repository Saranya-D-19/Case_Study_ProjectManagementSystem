using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_management_System.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public string Status { get; set; }

        public Project(int Id, string ProjectName, string Description, DateTime StartDate, string Status)
        {
            this.Id = Id;
            this.ProjectName = ProjectName;
            this.Description = Description;
            this.StartDate = StartDate;
            this.Status = Status;
        }


    }
}
