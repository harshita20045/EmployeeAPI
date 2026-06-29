using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var employees =await _services.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee =await _services.GetEmployeeById(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> Create(AddEmployeeInput employee)
        {
            if (employee == null)
                return BadRequest();

            await _services.AddEmployee(employee);
            return Ok(new{message="employee added successfully",data=employee});
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

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var employee = _services.GetEmployeeById(id);

        //    if (employee == null)
        //        return NotFound();

        //    _services.DeleteEmployee(employee);
        //    return Ok();
        //}

        [HttpGet("{id}/projects")]
        public IActionResult GetProjectOfEmployee(int id) {
            var projects = _services.GetProjectOfEmployee(id);
            return Ok(projects);
        }
    }
}