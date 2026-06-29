using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.DTOs;


namespace EmployeeAPI.Application.Interfaces
{
    public interface IDepartmentService
    {
        public Task<AddDepartmentDto> AddDepartment(AddDepartmentDto department);
    }
}
