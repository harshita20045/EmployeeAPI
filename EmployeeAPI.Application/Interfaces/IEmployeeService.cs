using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<EmployeeDto> AddEmployee(AddEmployeeInput employee);


        public Task<UpdateEmployeeDto> UpdateEmployee(UpdateEmployeeDto employee);

        public Task<bool> DeleteEmployee(int id);


        public Task<EmployeeDto> GetEmployeeById(int id);


        public Task<IEnumerable<EmployeeDto>> GetAllEmployees();

        public Task<IEnumerable<ProjectDto>> GetProjectOfEmployee(int id);

        public Task<bool> AssignProject(int projectId, int employeeId);





    }
}
