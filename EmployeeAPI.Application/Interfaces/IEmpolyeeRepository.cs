using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);

        public void UpdateEmployee(Employee employee);

        public void DeleteEmployee(Employee employee);

        public Employee GetEmployeeById(int id);

        public IEnumerable<Employee> GetAllEmployees();


    }
}
