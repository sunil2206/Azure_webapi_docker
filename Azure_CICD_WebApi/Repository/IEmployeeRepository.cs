using Azure_CICD_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_CICD_WebApi.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee employee);
        bool RemoveEmployee(int id);
    }
}
