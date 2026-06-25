using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Application.Interfaces;

namespace EmployeeAPI.Application.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeService(IEmployeeRepository employee)
        {
            _employee = employee;
        }

           public Employee AddEmployee(Employee employee)
         {
            Console.WriteLine("Service Hit");  
            _employee.AddEmployee(employee);
            return employee;
        }
        public void DeleteEmployee(Employee employee)
        {
            _employee.DeleteEmployee(employee);

        }
        public Employee UpdateEmployee(Employee employee)
         {
            _employee.UpdateEmployee(employee);
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employee.GetEmployeeById(id);
        }

          public IEnumerable<Employee> GetAllEmployees()
        {
            return _employee.GetAllEmployees();
        }
    }
}