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
    public class EmployeeService: IEmployeeService
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
         var emp= await  _employee.AddEmployee(employee);
            return new EmployeeDto
            {
                Id=emp.Id,
                FirstName = emp.FirstName,
                LastName = emp.LastName,
                Email = emp.Email,

            };
        }
        public async Task<bool> DeleteEmployee(int id)
        {

         return await  _employee.DeleteEmployee(id);


        }
        public Employee UpdateEmployee(Employee employee)
         {
            _employee.UpdateEmployee(employee);
            return employee;
        }

        public async Task<EmployeeDto> GetEmployeeById(int id)
        {
            return await _employee.GetEmployeeById(id);
        }

          public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            return await _employee.GetAllEmployees();
        }
        public IEnumerable<Project> GetProjectOfEmployee(int id) {
            return _employee.GetProjectOfEmployee(id);
        
        }

        public async Task<bool> AssignProject(int projectId, int employeeId)
        {

            return await _employee.AssignProject(projectId, employeeId);
        }

    }
}