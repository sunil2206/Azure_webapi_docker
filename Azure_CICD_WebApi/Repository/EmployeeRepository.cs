using Azure_CICD_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_CICD_WebApi.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private List<Employee> Employees;
        public EmployeeRepository()
        {
            Employees = new List<Employee>();
        }
        public bool AddEmployee(Employee employee)
        {

            int cnt = 0;
            if (Employees != null) {
                cnt = Employees.Count;
            }
            this.Employees.Add(employee);
            if (Employees.Count - cnt == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee GetEmployee(int id)
        {
            return this.Employees.First(emp => emp.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return this.Employees;
        }

        public bool RemoveEmployee(int id)
        {
            int cnt = Employees.Count;
            Employee emp = GetEmployee(id);
            this.Employees.Remove(emp);
            if (cnt - Employees.Count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
       
    }
}
