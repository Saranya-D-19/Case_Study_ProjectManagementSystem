using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_management_System.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Gender { get; set; }
        public double Salary { get; set; }
        public int Project_Id{ get; set; }

        

        public Employee(int Id,string Name,string Designation,string Gender,double Salary,int Project_Id)
        {
            this.Id = Id;
            this.Name = Name;
            this.Designation = Designation;
            this.Gender = Gender;
            this.Salary = Salary;
            this.Project_Id = Project_Id;

        }


    }
}
