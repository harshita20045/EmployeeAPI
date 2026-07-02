using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeAPI.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _services;

        public DepartmentController(IDepartmentService services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentDto department)
        {
            await _services.AddDepartment(department);
            return Ok(new
            {
                message = "Department added successfully",
                data = department
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {

            var department = await _services.GetDepartmentById(id);
            return Ok(new
            {
                message = "Department added successfully",
                data = department
            });
        }

        [HttpPut]

        public async Task<IActionResult> UpdateDepartment(UpdateDepartmentDto dto)
        {
            var department = await _services.UpdateDepartment(dto);

            return Ok(new
            {
                message = "Department updated successfully",
                data = department
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartment()
        {
            var departments = await _services.GetAllDepartments();
            return Ok(new
            {
                message = " All Department :-",
                data = departments
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _services.DeleteDepartment(id);
            if (result == false)
            {
                return Ok(new
                {
                    message = "Not Deleted Successfuly....",

                });
            }
            return Ok(new
            {
                message = "Deleted Successfuly....",

            });
        }

        [HttpGet("{id}/employees")]
        public async Task<IActionResult> GetEmployeeInDepartment(int id)
        {
            var employees = await _services.GetEmployeeInDepartment(id);
            return Ok(new
            {
                message = "Deleted Successfuly....",
                data = employees
            });
        }
    }
}
