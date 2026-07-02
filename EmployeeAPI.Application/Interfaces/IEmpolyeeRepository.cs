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

        public Task<Employee> UpdateEmployee(Employee employee);

        public Task<bool> DeleteEmployee(int id);

        public Task<Employee> GetEmployeeById(int id);

        public Task<IEnumerable<Employee>> GetAllEmployees();
        public Task<IEnumerable<Project>> GetProjectOfEmployee(int id);
        public Task<bool> AssignProject(int projectId, int employeeId);





    }
}
