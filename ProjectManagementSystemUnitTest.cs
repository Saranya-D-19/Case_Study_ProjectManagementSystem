using NUnit.Framework;
using Project_management_System.DAO;
using Project_management_System.Entity;
using System.Collections.Generic;

namespace ProjectManagementSystem.Tests
{
    public class ProjectManagementSystemUnitTest
    {
        private IProjectRepository _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new ProjectRepositoryImpl();
        }

        // Test case: Create employee successfully
        [Test]
        public void CreateEmployee_ShouldReturnTrue()
        {
            var emp = new Employee(30, "Rinthiya", "Tester", "Female", 60000, 1);
            bool result = _repo.createEmployee(emp);
            Assert.IsTrue(result);
        }

        // Test case: Create task successfully
        [Test]
        public void CreateTask_ShouldReturnTrue()
        {
            var task = new EntityTask(130, "UnitTestTask", 1, 2, "Assigned");
            bool result = _repo.createTask(task);
            Assert.IsTrue(result);
        }

        //  Test case: Search tasks assigned to an employee
        [Test]
        public void GetAllTasks_ShouldReturnNonEmptyList()
        {
            List<EntityTask> tasks = _repo.GetAllTasks(3, 2);
            Assert.IsNotNull(tasks);
            Assert.IsTrue(tasks.Count > 0);
        }

        // Test case: Handle exception scenario
        [Test]
        public void DeleteNonExistingEmployee_ShouldReturnFalse()
        {
            bool result = _repo.deleteEmployee(100); // assuming 100 doesn't exist
            Assert.IsFalse(result);
        }
    }
}
