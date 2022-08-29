using Azure_CICD_WebApi.Models;
using Azure_CICD_WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_CICD_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("employees")]
        public ActionResult GetEmployees() {
            return Ok(this._repository.GetEmployees());
        }
        [HttpGet("employee/{id}")]
        public ActionResult GetEmployee(int id)
        {
            return Ok(this._repository.GetEmployee(id));
        }
        [HttpDelete("removeEmployee")]
        public ActionResult DeleteEmployee(int id)
        {
            return Ok(this._repository.RemoveEmployee(id));
        }
        [HttpPost("addEmployee")]
        public ActionResult AddEmployee(Employee emp)
        {
            if (ModelState.IsValid)
            {
                return Ok(this._repository.AddEmployee(emp));
            }
            else {
                return BadRequest();
            }
        }
    }
}
