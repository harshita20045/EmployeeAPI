using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

    
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _repository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _repository.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

  
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (employee == null)
                return BadRequest();

            _repository.AddEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            var existing = _repository.GetEmployeeById(id);
            if (existing == null)
                return NotFound();

            _repository.UpdateEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var employee = _repository.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            _repository.DeleteEmployee(employee);
            return Ok();
        }
    }
}