using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;

namespace EmployeeAPI.Graphql.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class DepartmentQuery
    {

      public async Task<IEnumerable<DepartmentDto>> GetAllDepartment([Service] IDepartmentService _department)
        {
            return await _department.GetAllDepartments();
        }
       
        public async Task<DepartmentDto> GetDepartmentById(int id, [Service] IDepartmentService _department)
        {
            return await _department.GetDepartmentById(id);
        }
        
       
        public async Task<IEnumerable<EmployeeListDto>> GetEmployeeInDepartment(int id, [Service]IDepartmentService _department)
        {
            return await _department.GetEmployeeInDepartment(id);
        }
    }
}
