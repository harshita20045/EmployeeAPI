using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Application.DTOs;

namespace EmployeeAPI.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeService(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public async Task<EmployeeDto> AddEmployee(AddEmployeeInput dto)
        {
            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DepartmentId = dto.DepartmentId
            };
            var emp = await _employee.AddEmployee(employee);
            return new EmployeeDto
            {
                Id = emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,

            };
        }
        public async Task<bool> DeleteEmployee(int id)
        {

            return await _employee.DeleteEmployee(id);


        }
        public async Task<UpdateEmployeeDto> UpdateEmployee(UpdateEmployeeDto employee)
        {

            await _employee.UpdateEmployee(new Employee
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId
            });


            return employee;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            var employee = await _employee.GetEmployeeById(id);

            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DepartmentName = employee.Department.Name
            };
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {

            var employees = await _employee.GetAllEmployees();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DepartmentName = e.Department.Name
            });
        }
        public async Task<IEnumerable<ProjectDto>> GetProjectOfEmployee(int id)
        {

            var projects = await _employee.GetProjectOfEmployee(id);
            return projects.Select(p => new ProjectDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Duration = p.Duration,
                Status = p.Status
            });

        }

        public async Task<bool> AssignProject(int projectId, int employeeId)
        {

            return await _employee.AssignProject(projectId, employeeId);
        }

    }
}