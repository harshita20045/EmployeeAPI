using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;

namespace EmployeeAPI.Graphql.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class ProjectMutation
    {

        public async Task<AddProjectDto> AddProject(AddProjectDto project, [Service] IProjectService _project)
        {
            return await _project.AddProject(project);

        }
        public async Task<bool> DeleteProject(int id, [Service] IProjectService _project)
        {
            return await _project.DeleteProject(id);
        }
        public async Task<ProjectDto> UpdateProject(ProjectDto project, [Service] IProjectService _project)
        {
            return await _project.UpdateProject(project);
        }
    }
}
