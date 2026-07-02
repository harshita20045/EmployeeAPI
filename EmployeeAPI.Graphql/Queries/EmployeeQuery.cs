using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Application.DTOs;



namespace EmployeeAPI.Graphql.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class EmployeeQuery
    {
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees([Service] IEmployeeService employeeService)
        {
            return await employeeService.GetAllEmployees();
        }
        public async Task<EmployeeDto> GetEmployeeById(int id, [Service] IEmployeeService employeeService)
        {
            var employee = await employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                throw new Exception("Something went wrong");
            }
            return await Task.FromResult(employee);
        }

        public async Task<IEnumerable<ProjectDto>> GetProjectOfEmployee(int id, [Service] IEmployeeService employeeService)
        {
            return await employeeService.GetProjectOfEmployee(id);
        }
    }
}
