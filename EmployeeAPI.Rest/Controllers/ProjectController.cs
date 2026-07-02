using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Rest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProject()
        {
            var projects = await _service.GetProject();
            return Ok(new
            {

                message = "All Projects",
                data = projects
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await _service.DeleteProject(id);
            return Ok(new
            {

                message = "Project deleted successfully",
                data = result
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(int id)
        {

            var project = await _service.GetProjectById(id);
            return Ok(new
            {
                message = "Project By Id :- ",
                data = project
            });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProject(ProjectDto dto)
        {
            var project = await _service.UpdateProject(dto);
            return Ok(new
            {

                message = "Project updated successfully",
                data = project
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddProject([FromBody] AddProjectDto dto)
        {
            Console.WriteLine("cc", dto);
            var project = await _service.AddProject(dto);
            return Ok(new
            {

                message = "Project added successfully",
                data = project
            });
        }
    }
}
