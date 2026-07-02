using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;

namespace EmployeeAPI.Graphql.Mutations
{
    [ExtendObjectType(typeof(Mutation))]
    public class DepartmentMutation
    {
        public async Task<AddDepartmentDto> AddDepartment(AddDepartmentDto department, [Service] IDepartmentService _department)
        {
            return await _department.AddDepartment(department);

        }

        public async Task<DepartmentDto> UpdateDepartment(UpdateDepartmentDto department, [Service] IDepartmentService _department)
        {
            return await _department.UpdateDepartment(department);
        }

        public async Task<bool> DeleteDepartment(int id, [Service] IDepartmentService _department)
        {
            return await _department.DeleteDepartment(id);
        }
    }
}
