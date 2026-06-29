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


        public Employee UpdateEmployee(Employee employee);

        public void DeleteEmployee(Employee employee);


      public Task<EmployeeDto> GetEmployeeById(int id);
 

      public Task<IEnumerable<EmployeeDto>> GetAllEmployees();

        public IEnumerable<Project> GetProjectOfEmployee(int id);





    }
}
