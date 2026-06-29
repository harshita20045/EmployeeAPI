using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Application.DTOs;
namespace EmployeeAPI.Graphql.Mutations

{
    public class EmployeeMutation
    {
         
        public async Task<EmployeeDto> AddEmployee(
      AddEmployeeInput input,
      [Service] IEmployeeService employeeService)
        {
            return await employeeService.AddEmployee(input);
        }
        public Task<Employee> UpdateEmployee(Employee employee, [Service] IEmployeeService employeeService)
        {
            employeeService.UpdateEmployee(employee);
            return Task.FromResult(employee);
        }
        public bool DeleteEmployee(int id, [Service] IEmployeeService employeeService)
        {
            var employee = employeeService.GetEmployeeById(id);

            if (employee == null)
                return false;

            employeeService.DeleteEmployee(employee);
            return true;
        }
    }
}
