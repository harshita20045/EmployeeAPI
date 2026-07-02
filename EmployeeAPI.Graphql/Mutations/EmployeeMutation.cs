using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Application.DTOs;
namespace EmployeeAPI.Graphql.Mutations

{
    [ExtendObjectType(typeof(Mutation))]
    public class EmployeeMutation
    {

        public async Task<EmployeeDto> AddEmployee(
      AddEmployeeInput input,
      [Service] IEmployeeService employeeService)
        {
            return await employeeService.AddEmployee(input);
        }
        public Task<UpdateEmployeeDto> UpdateEmployee(UpdateEmployeeDto employee, [Service] IEmployeeService employeeService)
        {
            employeeService.UpdateEmployee(employee);
            return Task.FromResult(employee);
        }
        public async Task<bool> DeleteEmployee(int id, [Service] IEmployeeService employeeService)
        {

            return await employeeService.DeleteEmployee(id);

        }

        public async Task<bool> AssignProject(int projectId,int employeeId, [Service] IEmployeeService employeeService) {
            return await employeeService.AssignProject(projectId,employeeId);
        }
    }
}
