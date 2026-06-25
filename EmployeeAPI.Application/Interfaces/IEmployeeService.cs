using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.Interfaces
{
public interface IEmployeeService
    {
        public Employee AddEmployee(Employee employee);


        public Employee UpdateEmployee(Employee employee);

        public void DeleteEmployee(Employee employee);


      public Employee GetEmployeeById(int id);
 

      public IEnumerable<Employee> GetAllEmployees();





    }
}
