using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Infrastructure.Data;

namespace EmployeeAPI.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            var Employee = new Employee
            {
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email
            };
     

            _context.Employees.Add(employee);

            _context.SaveChanges();

            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existing = _context.Employees.Find(employee.Id);

            if (existing == null)
            {
                throw new Exception($"Employee with Id {employee.Id} not found");
            }

           
            existing.FirstName = employee.FirstName;
            existing.LastName = employee.LastName;
            existing.Email = employee.Email;

            _context.SaveChanges();

            return existing;
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        

      
    }
}