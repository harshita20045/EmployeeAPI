using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.Services
{
    public class ProjectService :IProjectService
    {
        private readonly IProjectRepository _project;
        public ProjectService(IProjectRepository project)
        {
            _project = project;
        }
        public async Task<AddProjectDto> AddProject(AddProjectDto project)
        {
            var projt = new Project
            {
                Name = project.Name,
                Status=project.Status,
                Duration=project.Duration,
                Description=project.Description

            };
            Console.WriteLine("reh",projt);
            await _project.AddProject(projt);
            return project;
        }

        public async Task<bool> DeleteProject(int id)
        {
            return await _project.DeleteProject(id);
        }
        public async Task<IEnumerable<ProjectDto>> GetProject()
        {
            var project = await _project.GetProject();
            return project.Select(p=> new ProjectDto
            {
                Id=p.Id,
                Name = p.Name,
                Status = p.Status,
                Duration = p.Duration,
                Description = p.Description
            });
        }

        public async Task<ProjectDto> GetProjectById(int id) {
            var project = await _project.GetProjectById(id);

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Status = project.Status,
                Duration = project.Duration,
                Description = project.Description
            };
        }   

        public async Task<ProjectDto> UpdateProject(ProjectDto project) {

            var projt = new Project {
                Id = project.Id,
                Name = project.Name,
                Status = project.Status,
                Duration = project.Duration,
                Description = project.Description
            };
            await _project.UpdateProject(projt);
            return project;

        }
    }
}
