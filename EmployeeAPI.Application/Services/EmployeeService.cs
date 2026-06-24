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

           public void AddEmployee(Employee employee)
         {
            _employee.AddEmployee(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            _employee.DeleteEmployee(employee);

        }
        public void UpdateEmployee(Employee employee)
         {
            _employee.UpdateEmployee(employee);
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