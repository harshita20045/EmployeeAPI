using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeAPI.Graphql.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class ProjectQuery
    {



        public async Task<IEnumerable<ProjectDto>> GetProject([Service] IProjectService _project)
        {
            return await _project.GetProject();
        }
        public async Task<ProjectDto> GetProjectById(int id, [Service] IProjectService _project)
        {
            return await _project.GetProjectById(id);
        }

    }
}
