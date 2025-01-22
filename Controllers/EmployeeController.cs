using EmployeeManagementAPi.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<EmployeeResponse> employees = new List<EmployeeResponse>
        {
            new EmployeeRequest { EmpId = 1, EmpUserName = "Abhijeet", EmpPassword = "12345", EmpEmail = "abhijeet@gmail.com" },
            new EmployeeRequest { EmpId = 2, EmpUserName = "Parth", EmpPassword = "12345", EmpEmail = "parth@gmail.com" , EmpPosition = "CE0", EmpSalary=100000},
            new EmployeeRequest { EmpId = 3, EmpUserName = "tanvi", EmpPassword = "12345", EmpEmail = "tanvi@gmail.com", EmpPosition = "CT0", EmpSalary=100000 }
        };

        [HttpPost]
        public IActionResult CreateEmployee( EmployeeRequest employee)
        {
            if (employee == null)
            {
                return BadRequest("this field required");
            }

            employees.Add(employee);
            return CreatedAtAction(nameof(GetAllEmployee), new { Empid = employee.EmpId }, employee);
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(employees);
        }

        [HttpGet("{Empid}")]
        public IActionResult GetEmployeeByID(int Empid)
        {
            if (employees == null)
            {
                return BadRequest("this field required");
            }

            var employee = employees.Find(e => e.EmpId == Empid);
            return Ok(employee);
        }

        [HttpPut("{Empid}")]
        public IActionResult updateEmployeeByID(int Empid, EmployeeRequest updateEmployee)
        {
            if (updateEmployee == null)
            {
                return BadRequest("this field required");
            }

            var index = employees.FindIndex(e => e.EmpId == Empid);

            if (index == -1)
            {
                return NotFound("not available");
            }
            employees[index] = updateEmployee;
            return Ok();
        }

        [HttpDelete("{Empid}")]
        public IActionResult DeleteEmployeeByID(int Empid)
        {
            if (Empid == null)
            {
                return BadRequest("this field required");
            }
            var index = employees.FindIndex(e => e.EmpId == Empid);
            if (index == -1)
            {
                return NotFound("not available");
            }
            employees.RemoveAt(index);
            return Ok("deleted");
        }
    }
}
