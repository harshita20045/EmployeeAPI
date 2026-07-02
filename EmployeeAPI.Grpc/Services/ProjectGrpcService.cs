using EmployeeAPI.Application.Interfaces;
using Grpc.Core;

namespace EmployeeAPI.Grpc.Services
{
    public class ProjectGrpcService : ProjectGrpc.ProjectGrpcBase
    {
        private readonly IProjectService _project;
        public ProjectGrpcService(IProjectService project)
        {
            _project = project;
        }
        public override async Task<CreateProjectResponse> CreateProject(CreateProjectRequest request, ServerCallContext context)
        {
            var project = await _project.AddProject(new Application.DTOs.AddProjectDto
            {
                Name = request.Name,
                Description = request.Description,
                Duration = request.Duration,
                Status = (EmployeeAPI.Domain.Entities.ProjectStatus)request.Status
            });
            return new CreateProjectResponse
            {
                Name = project.Name,
                Description = project.Description,
                Duration = project.Duration,
                Status = (EmployeeAPI.Grpc.ProjectStatus)project.Status
            };
        }

        public override async Task<DeleteProjectResponse> DeleteProject(DeleteProjectRequest request, ServerCallContext context)
        {
            var result = await _project.DeleteProject(request.Id);
            return new DeleteProjectResponse
            {
                Result = result
            };
        }

        public override async Task<GetAllProjectResponse> GetAllProject(EmptyProjectequest request, ServerCallContext context)
        {
            var projects = await _project.GetProject();
            var response = new GetAllProjectResponse();
            response.Projects.AddRange(projects.Select(p => new GetProjectResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Duration = p.Duration,
                Status = (EmployeeAPI.Grpc.ProjectStatus)p.Status
            }));
            return response;
        }
        public override async Task<GetProjectResponse> GetProjectById(GetProjectByIdRequest request, ServerCallContext context)
        {
            var project = await _project.GetProjectById(request.Id);
            return new GetProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Duration = project.Duration,
                Status = (EmployeeAPI.Grpc.ProjectStatus)project.Status

            };
        }
        public override async Task<GetProjectResponse> UpdateProject(UpdateProjectRequest request, ServerCallContext context)
        {
            var project = await _project.UpdateProject(new Application.DTOs.ProjectDto
            {
                Id = request.Id,
                Name = request.Name,
                Status = (EmployeeAPI.Domain.Entities.ProjectStatus)request.Status,
                Duration = request.Duration,
                Description = request.Description

            });

            return new GetProjectResponse
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Duration = project.Duration,
                Status = (EmployeeAPI.Grpc.ProjectStatus)project.Status
            };
        }
    }
}
