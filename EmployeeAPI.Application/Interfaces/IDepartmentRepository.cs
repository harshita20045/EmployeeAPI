using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.DTOs;

namespace EmployeeAPI.Application.Interfaces
{
   public interface IDepartmentRepository
    {
        public Task<Department> AddDepartment(Department department);

        public Task<Department> UpdateDepartment(Department department);

        public Task<Department> GetDepartmentById(int id);

        public Task<bool> DeleteDepartment(int id);

        public Task<IEnumerable<Employee>> GetEmployeeInDepartment(int id);

        public Task<IEnumerable<Department>> GetAllDepartments();


    }
}
