namespace EmployeeAPI.Application.DTOs
{
    public class AddEmployeeInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int DepartmentId { get; set; }
    }
}