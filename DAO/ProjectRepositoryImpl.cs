using Project_management_System.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Project_management_System.Util;


namespace Project_management_System.DAO
{
    public  class ProjectRepositoryImpl : IProjectRepository
    {
        public bool createEmployee(Employee emp)
        {
            using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
            {
                string query = $"INSERT INTO Employee (Id, Name, Designation, Gender, Salary, Project_Id) " +
                               "VALUES (@Id, @Name, @Designation, @Gender, @Salary, @Project_Id)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", emp.Id);
                    cmd.Parameters.AddWithValue("@Name", emp.Name);
                    cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@Project_Id", emp.Project_Id);

                    connection.Open();
                    int rowsAdded = cmd.ExecuteNonQuery();

                    return rowsAdded > 0;
                }
            }
           
        }

        public bool deleteEmployee(int empid) {
            
                using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
                {
                    string query = $"DELETE FROM Employee WHERE Id = @empid";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@empid", empid);

                        connection.Open();
                        int rowDeleted = cmd.ExecuteNonQuery();

                    return rowDeleted > 0;
                    }
                }
            
        }


        public bool createProject(Project pj)
        {

            using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
            {
                string query = $"INSERT INTO Project (Id, ProjectName, Description, StartDate, Status) " +
                               "VALUES (@Id, @ProjectName, @Description, @StartDate, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", pj.Id);
                    cmd.Parameters.AddWithValue("@ProjectName", pj.ProjectName);
                    cmd.Parameters.AddWithValue("@Description", pj.Description);
                    cmd.Parameters.AddWithValue("@StartDate", pj.StartDate);
                    cmd.Parameters.AddWithValue("@Status", pj.Status);

                    connection.Open();
                    int rowsAdded = cmd.ExecuteNonQuery();

                    return rowsAdded > 0;

                }
            }
        }

        public bool deleteProject(int projectId)
        {
            
                using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
                {
                    string query = $"DELETE FROM Project WHERE Id = @projectId";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@projectId", projectId);

                        connection.Open();
                        int rowDeleted = cmd.ExecuteNonQuery();

                    return rowDeleted > 0;
                       
                    }
                }
        }

        public bool assignProjectToEmployee(int project_Id, int employeeId) { 
          
                using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
                {
                    string query = "UPDATE Employee SET Project_Id = @project_Id WHERE Id = @employeeId";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@project_Id", project_Id);
                        cmd.Parameters.AddWithValue("@employeeId", employeeId);

                        connection.Open();
                        int rowUpdated = cmd.ExecuteNonQuery();
                    
                    return rowUpdated > 0;
                        
                    }
                }
            
        }
 

        public bool createTask(EntityTask task) {
           
                using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
                {
                    string query = $"INSERT INTO Task (Task_Id, TaskName, Project_Id, Employee_Id, Status) " +
                                   "VALUES (@Task_Id, @TaskName, @Project_Id, @Employee_Id, @Status)";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Task_Id", task.Task_Id);
                        cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                        cmd.Parameters.AddWithValue("@Project_Id", task.Project_Id);
                        cmd.Parameters.AddWithValue("@Employee_Id", task.Employee_Id);
                        cmd.Parameters.AddWithValue("@Status", task.Status);

                        connection.Open();
                        int rowsAdded = cmd.ExecuteNonQuery();

                    return rowsAdded > 0;
                    }
                }
        }

        public bool assignTaskInProjectToEmployee(int task_Id, int project_Id, int employee_Id)
        {
            
                using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
                {
                    string query = $"UPDATE Task SET Project_Id=@Project_Id,Employee_Id=@Employee_Id WHERE Task_Id=@Task_Id";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Task_Id", task_Id);
                        cmd.Parameters.AddWithValue("@Project_Id", project_Id);
                        cmd.Parameters.AddWithValue("@Employee_Id", employee_Id);

                        connection.Open();
                        int rowsAdded = cmd.ExecuteNonQuery();

                    return rowsAdded > 0;
                    }
                }
        }


        public List<EntityTask> GetAllTasks(int employee_Id, int project_Id)
        {
            List<EntityTask> tasks = new List<EntityTask>();
            
                using (SqlConnection connection = DBConnUtil.GetConnection("db.properties.txt.properties"))
                {
                    string query = $"SELECT * FROM Task WHERE Employee_Id=@Employee_Id AND Project_Id=@Project_Id";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {

                        cmd.Parameters.AddWithValue("@Employee_Id", employee_Id);
                        cmd.Parameters.AddWithValue("@Project_Id", project_Id);

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EntityTask task = new EntityTask()
                            {
                                Task_Id = (int)reader["Task_Id"],
                                TaskName = reader["TaskName"].ToString(),
                                Project_Id = (int)reader["Project_Id"],
                                Employee_Id = (int)reader["Employee_Id"],
                                Status = reader["Status"].ToString()
                            };
                            tasks.Add(task);
                        }
                    }
                }
           
            return tasks;
        }
    }
}
