using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.Interfaces
{
    public interface IProjectRepository
    {
        public Task<Project> AddProject(Project project);
        public Task<bool> DeleteProject(int id);
        public Task<IEnumerable<Project>> GetProject();
        public Task<Project> GetProjectById(int id);
        public Task<Project> UpdateProject(Project project);

       
    }
}
