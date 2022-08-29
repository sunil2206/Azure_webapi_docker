using Azure_CICD_WebApi.Repository;
using Azure_CICD_WebApi.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace Azure_CICD_WebApi_test
{
    public class EmployeeRepositoryTest
    {
        EmployeeRepository repo;

        [TearDown]
        public void AddEmployeeData()
        {
            repo = new EmployeeRepository();
            repo.AddEmployee(new Employee { Id = 1, Name = "Marsh" });
            repo.AddEmployee(new Employee { Id = 2, Name = "Mike" });
            Assert.AreEqual(repo.GetEmployees().Count, 2);
        }


        [Test]
        public void AddEmployee_should_remove_the_employee_of_given_id()
        {
            repo = new EmployeeRepository();
            Employee emp = new Employee { Id = 1, Name = "Marsh" };
            bool result = repo.AddEmployee(emp);
            Assert.AreEqual(repo.GetEmployees().Count,1);
        }
      
        [Test]
        public void RemoveEmployee_should_remove_the_employee_of_given_id()
        {    
            bool result = repo.RemoveEmployee(1);
            Assert.IsTrue(result);
        }
        
        [Test]
        public void GetEmployees_should_return_list_of_employees()
        {
            List<Employee> employees = repo.GetEmployees();
            Assert.AreEqual(employees.Count, 2);
        }
        [Test]
        public void GetEmployee_should_employee_for_given_id()
        {
            Employee employee = repo.GetEmployee(1);
            Assert.IsNotNull(employee);
        }
    }
}