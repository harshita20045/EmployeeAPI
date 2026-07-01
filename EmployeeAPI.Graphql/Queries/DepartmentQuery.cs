using EmployeeAPI.Application.DTOs;
using EmployeeAPI.Application.Interfaces;
using Microsoft.Identity.Client;

namespace EmployeeAPI.Graphql.Queries
{
    public class DepartmentQuery
    {

      public async Task<IEnumerable<DepartmentDto>> GetAllEmployee([Service] IDepartmentService department)
        {
            return await department.GetAllDepartments();
        }
    }
}
