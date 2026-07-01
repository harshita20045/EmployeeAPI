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

        public async Task<DepartmentDto> GetDepartmentById(int id) {
            var dept = await _department.GetDepartmentById(id);
            return new DepartmentDto { 
            Name=dept.Name
            };
        }

        public async Task<DepartmentDto> UpdateDepartment(UpdateDepartmentDto department)
        {
            var dept = new Department
            {
                Id = department.Id,
                Name=department.Name
            };
            await _department.UpdateDepartment(dept);
            return new DepartmentDto
            {
                Name = dept.Name
            };

        }

        public async Task<bool> DeleteDepartment(int id)
        {
            
            return await _department.DeleteDepartment(id);
        }

        public async Task<IEnumerable<EmployeeListDto>> GetEmployeeInDepartment(int id)
        {

           var employees= await _department.GetEmployeeInDepartment(id);

            return employees.Select(e=> new EmployeeListDto
            {
               
                FirstName=e.FirstName,
                LastName=e.LastName,
                Email=e.Email


            });
        }
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartments()
        {
            var department= await _department.GetAllDepartments();
            return department.Select(d=>new DepartmentDto
            {
                Name=d.Name
            });
        }
    }
}
