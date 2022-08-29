using Azure_CICD_WebApi.Controllers;
using Azure_CICD_WebApi.Models;
using Azure_CICD_WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Azure_CICD_WebApi_test
{
    class EmployeeControllerTest
    {
        EmployeeRepository repo;
        EmployeeController Controller;
        public void Setup() {
            repo = new EmployeeRepository(); 
            Controller = new EmployeeController(repo); 
        }
       

        [Test]
        public void GetEmployee_endpoint_should_return_mathcing_employee()
        {
            repo = new EmployeeRepository();
            Controller = new EmployeeController(repo);
            repo.AddEmployee(new Employee { Id = 1, Name = "Marsh" });
            var result = Controller.GetEmployee(1);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void AddEmployee_endpoint_should_return_true_if_correct_employee_object_is_passed()
        {
            repo = new EmployeeRepository();
            Controller = new EmployeeController(repo);
            var result = Controller.AddEmployee(new Employee { Id = 1, Name = "Marsh" });
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        [Test]
        public void GetEmployees_endpoint_should_return_list_of_employees_in_okResult_type()
        {
            repo = new EmployeeRepository();
            Controller = new EmployeeController(repo);
            repo.AddEmployee(new Employee { Id = 1, Name = "Marsh" });
            repo.AddEmployee(new Employee { Id = 2, Name = "jack" });
            var result = Controller.GetEmployees();
            Assert.IsInstanceOf<OkObjectResult>(result);
        }
        [Test]
        public void RemoveEmployees_endpoint_should_return_true_if_employee_is_removed()
        {
            repo = new EmployeeRepository();
            Controller = new EmployeeController(repo);
            repo.AddEmployee(new Employee { Id = 1, Name = "Marsh" });
            repo.AddEmployee(new Employee { Id = 2, Name = "jack" });
            var result = Controller.DeleteEmployee(2);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }


    }
}
