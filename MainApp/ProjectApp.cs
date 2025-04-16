using System;
using Project_management_System.DAO;
using Project_management_System.Entity;
using Project_management_System.MyExceptions;
using System.Collections.Generic;

namespace Project_management_System
    {
        class ProjectApp
        {
            public static void Main(string[] args)
            {
                IProjectRepository repository = new ProjectRepositoryImpl();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n==== Project Management Menu ====");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Add Project");
                    Console.WriteLine("3. Add Task");
                    Console.WriteLine("4. Assign Project to Employee");
                    Console.WriteLine("5. Assign Task within Project to Employee");
                    Console.WriteLine("6. Delete Employee");
                    Console.WriteLine("7. Delete Project");
                    Console.WriteLine("8. Show All Tasks Assigned to Employee in Project");
                    Console.WriteLine("9. Exit");
                    Console.Write("Enter your choice: ");

                    int choice = int.Parse(Console.ReadLine());

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter Employee ID: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.Write("Enter Name: ");
                                string name = Console.ReadLine();
                                Console.Write("Enter Designation: ");
                                string designation = Console.ReadLine();
                                Console.Write("Enter Gender: ");
                                string gender = Console.ReadLine();
                                Console.Write("Enter Salary: ");
                                double salary = double.Parse(Console.ReadLine());
                                Console.Write("Enter Project ID: ");
                                int projectId = int.Parse(Console.ReadLine());

                                Employee emp = new Employee(id, name, designation, gender, salary, projectId);
                                bool created = repository.createEmployee(emp);
                                Console.WriteLine(created ? "Employee created successfully." : "Failed to create employee.");
                                break;

                            case 2:
                                Console.Write("Enter Project ID: ");
                                int project_id = int.Parse(Console.ReadLine());
                                Console.Write("Enter Project Name: ");
                                string projectName = Console.ReadLine();
                                Console.Write("Enter Description: ");
                                string description = Console.ReadLine();
                                Console.Write("Enter Start Date (yyyy-mm-dd): ");
                                DateTime startdate = DateTime.Parse(Console.ReadLine());
                                Console.Write("Enter Status('Started','Dev','Built','Test','Deployed'): ");
                                string status = Console.ReadLine();

                                Project pj = new Project(project_id, projectName, description, startdate, status);
                                bool projectCreated = repository.createProject(pj);
                                Console.WriteLine(projectCreated ? "Project created successfully." : "Failed to create project.");
                                break;

                            case 3:
                                Console.Write("Enter Task ID: ");
                                int task_Id = int.Parse(Console.ReadLine());
                                Console.Write("Enter Task Name: ");
                                string taskName = Console.ReadLine();
                                Console.Write("Enter Project ID: ");
                                int project_Id = int.Parse(Console.ReadLine());
                                Console.Write("Enter Employee ID: ");
                                int employee_Id = int.Parse(Console.ReadLine());
                                Console.Write("Enter Status ('Assigned','Started','Completed'): ");
                                string taskStatus = Console.ReadLine();

                                EntityTask task = new EntityTask(task_Id, taskName, project_Id, employee_Id, taskStatus);
                                bool taskCreated = repository.createTask(task);
                                Console.WriteLine(taskCreated ? "Task created successfully." : "Failed to create task.");
                                break;

                            case 4:
                                Console.Write("Enter Project ID: ");
                                int projectIdAssign = int.Parse(Console.ReadLine());
                                Console.Write("Enter Employee ID: ");
                                int empIdAssign = int.Parse(Console.ReadLine());

                                bool updated = repository.assignProjectToEmployee(projectIdAssign, empIdAssign);
                                if (!updated)
                                    throw new EmployeeNotFoundException($"Employee with ID {empIdAssign} not found.");

                                Console.WriteLine("Project assigned to employee successfully.");
                                break;

                            case 5:
                                Console.Write("Enter Task ID: ");
                                int taskAssignId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Project ID: ");
                                int projectAssignId = int.Parse(Console.ReadLine());
                                Console.Write("Enter Employee ID: ");
                                int empAssignId = int.Parse(Console.ReadLine());

                                bool taskAssigned = repository.assignTaskInProjectToEmployee(taskAssignId, projectAssignId, empAssignId);
                                Console.WriteLine(taskAssigned ? "Task assigned to employee successfully." : "Failed to assign task.");
                                break;

                            case 6:
                                Console.Write("Enter Employee ID to delete: ");
                                int empId = int.Parse(Console.ReadLine());
                            try
                            {
                                bool deleted = repository.deleteEmployee(empId);
                                if (!deleted)
                                    throw new EmployeeNotFoundException($"Employee with ID {empId} not found.");

                                Console.WriteLine("Employee deleted successfully.");
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("Cannot delete employee. They are assigned to one or more tasks.");
                            }
                                break;

                            case 7:
                                Console.Write("Enter Project ID to delete: ");
                                int projectDeleteId = int.Parse(Console.ReadLine());
                                bool projectDeleted = repository.deleteProject(projectDeleteId);
                                Console.WriteLine(projectDeleted ? "Project deleted successfully." : "Failed to delete Project.");
                                break;

                            case 8:
                                Console.Write("Enter Employee ID: ");
                                int empIdTasks = int.Parse(Console.ReadLine());
                                Console.Write("Enter Project ID: ");
                                int projectIdTasks = int.Parse(Console.ReadLine());

                                List<EntityTask> tasks = repository.GetAllTasks(empIdTasks, projectIdTasks);

                                if (tasks.Count == 0)
                                {
                                    Console.WriteLine("No tasks assigned.");
                                }
                                else
                                {
                                    Console.WriteLine("\nAssigned Tasks:");
                                    foreach (var taskItem in tasks)
                                    {
                                        Console.WriteLine($"Task ID: {taskItem.Task_Id}, Name: {taskItem.TaskName}, Status: {taskItem.Status}, Project ID: {taskItem.Project_Id}, Employee ID: {taskItem.Employee_Id}");
                                    }
                                }
                                break;

                            case 9:
                                exit = true;
                            Console.WriteLine("Exit");
                                break;


                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                    }
                }
            }
        }
}


