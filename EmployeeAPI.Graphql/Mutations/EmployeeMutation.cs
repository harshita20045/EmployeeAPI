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
