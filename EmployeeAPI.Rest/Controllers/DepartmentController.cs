using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeAPI.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController :ControllerBase
    {
        private readonly IDepartmentService _services;

        public DepartmentController(IDepartmentService services) {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentDto department) {
          await  _services.AddDepartment(department);
            return Ok(new
            {
                message = "Department added successfully",
                data = department
            });
        }
    }
}
