using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Application.DTOs;

namespace EmployeeAPI.Application.Interfaces
{
    public interface IProjectService
    {
        public Task<AddProjectDto> AddProject(AddProjectDto project);
        public Task<bool> DeleteProject(int id);
        public Task<IEnumerable<ProjectDto>> GetProject();
        public Task<ProjectDto> GetProjectById(int id);
        public Task<ProjectDto> UpdateProject(ProjectDto project);
    }
}
