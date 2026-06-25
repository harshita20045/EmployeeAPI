using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _services;

        public EmployeeController(IEmployeeService services)
        {
            _services = services;
        }

    
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _services.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _services.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

  
        [HttpPost]
         public IActionResult Create(Employee employee)
        {
             if (employee == null)
                return BadRequest();

            _services.AddEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            var existing = _services.GetEmployeeById(id);
            if (existing == null)
                return NotFound();

            _services.UpdateEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _services.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            _services.DeleteEmployee(employee);
            return Ok();
        }
    }
}