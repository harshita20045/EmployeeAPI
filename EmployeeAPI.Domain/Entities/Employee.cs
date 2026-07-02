namespace EmployeeAPI.Domain.Entities
{

    public enum EmployeeGender
    {
        male,
        female,
        other
    }
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public EmployeeGender? Gender { get; set; }

        public string Email { get; set; }

        public string? PhoneNo { get; set; }

        public DateTime? DOB { get; set; }

        public int DepartmentId { get; set; }

        public Department? Department { get; set; }

        public List<Project> Projects { get; set; } = new();
    }
}
