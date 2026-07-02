using System.Diagnostics.Metrics;
using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
           await _context.Employees.AddAsync(employee);

           await _context.SaveChangesAsync();

            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existing = _context.Employees.Find(employee.Id);

            if (existing == null)
            {
                throw new Exception($"Employee with Id {employee.Id} not found");
            }

           
            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Email = employee.Email;

            _context.SaveChanges();

            return existing;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e=>e.Id==id);

           _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<EmployeeDto?> GetEmployeeById(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return null;

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DepartmentName = employee.Department?.Name
            };
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return await _context.Employees.Include(e => e.Department).Select(e => new EmployeeDto {
         Id = e.Id,
         FirstName = e.FirstName,
         LastName = e.LastName,
         Email = e.Email,
         DepartmentName = e.Department.Name
     }).ToListAsync();
        }


        public IEnumerable<Project> GetProjectOfEmployee(int id) {

            return _context.Employees.Where(e=>e.Id==id).SelectMany(e=>e.Projects).ToList();
        }

        public async Task<bool> AssignProject(int projectId, int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            var projects = await _context.Projects.FindAsync(projectId);


            Console.WriteLine("employee",employee);
            Console.WriteLine(projects);
            employee.Projects.Add(projects);

            await _context.SaveChangesAsync();
            
            return true;
           
        }

    }
}