using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        public Task<Employee> AddEmployee(Employee employee);

        public Employee UpdateEmployee(Employee employee);

        public Task<bool> DeleteEmployee(int id);

        public Task<EmployeeDto?> GetEmployeeById(int id);

        public Task<IEnumerable<EmployeeDto>> GetAllEmployees();
        public IEnumerable<Project> GetProjectOfEmployee(int id);
        public Task<bool> AssignProject(int projectId, int employeeId);





    }
}
