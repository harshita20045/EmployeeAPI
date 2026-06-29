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

        //public Department UpdateDepartment(Department department);

        //public Department GetDepartmentById(int id);

        //public void DeleteDepartment(Department department);

        //public Department GetEmployeeInDepartment(int id);


    }
}
