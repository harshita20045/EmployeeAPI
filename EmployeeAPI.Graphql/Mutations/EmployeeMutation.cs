using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;
namespace EmployeeAPI.Graphql.Mutations

{
    public class EmployeeMutation
    {
           public  Task<Employee> AddEmployee(Employee employee, [Service] IEmployeeService employeeService)
        {
            employeeService.AddEmployee(employee);
            Console.WriteLine("Mutation Hit");
            return Task.FromResult(employee);
        }
            public Task<Employee> UpdateEmployee(Employee employee, [Service] IEmployeeService employeeService)
        {
            employeeService.UpdateEmployee(employee);
            return Task.FromResult(employee);
        }
         public void DeleteEmployee(int id, [Service] IEmployeeService employeeService)
        {
            var employee = employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                throw new Exception("Something went wrong");
            }
            employeeService.DeleteEmployee(employee);
           
        }
    }
}
