using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;   


namespace EmployeeAPI.Graphql.Queries
{
    public class EmployeeQuery
    {
        public Task<IEnumerable<Employee>> GetAllEmployees([Service] IEmployeeService employeeService)
        {
            return Task.FromResult(employeeService.GetAllEmployees());
        }
          public Task<Employee> GetEmployeeById(int id, [Service] IEmployeeService employeeService)
        {
            var employee = employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                throw new Exception("Something went wrong");
            }
            return Task.FromResult(employee);
        }
    }
}
