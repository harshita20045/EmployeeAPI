using EmployeeAPI.Domain.Entities;

namespace EmployeeAPI.Application.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string DepartmentName { get; set; }
       
    }
}