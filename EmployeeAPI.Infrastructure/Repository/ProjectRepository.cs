using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Infrastructure.Repository
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly AppDbContext _context;
        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Project> AddProject(Project project)
        {
            Console.WriteLine("reposito", project);
            await _context.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }
        public async Task<bool> DeleteProject(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IEnumerable<Project>> GetProject()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectById(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            var projt = await _context.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            projt.Name = project.Name;
            projt.Status = project.Status;
            projt.Duration = project.Duration;
            projt.Description = project.Description;

            await _context.SaveChangesAsync();

            return projt;

        }


    }
}
