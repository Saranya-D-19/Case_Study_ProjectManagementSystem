using Project_management_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_management_System.DAO
{
    public interface IProjectRepository
    {
        bool createEmployee(Employee emp);
        bool deleteEmployee(int empid);

        bool createProject(Project pj);

        bool deleteProject(int projectId);
        bool assignProjectToEmployee(int projectId, int employeeId);
        bool createTask(EntityTask task);
        bool assignTaskInProjectToEmployee(int taskId, int projectId, int employeeId);

        List<EntityTask> GetAllTasks(int employeeId, int projectId);
    }

  
}
