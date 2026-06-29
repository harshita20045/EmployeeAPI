using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;



namespace EmployeeAPI.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _department;
        public DepartmentService(IDepartmentRepository department) {
            _department = department;
        }

        public async Task<AddDepartmentDto> AddDepartment(AddDepartmentDto dto) {
            var department = new Department
            {
                Name = dto.Name
            };
           var dept=await _department.AddDepartment(department);
            return new AddDepartmentDto
            {
                Name = dept.Name
            };
        }
    }
}
