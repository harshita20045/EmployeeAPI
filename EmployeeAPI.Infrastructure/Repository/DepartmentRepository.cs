using EmployeeAPI.Application.Interfaces;
using EmployeeAPI.Domain.Entities;
using EmployeeAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;




namespace EmployeeAPI.Infrastructure.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Department> AddDepartment(Department department)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> GetDepartmentById(int id)
        {

            return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _context.Departments.ToListAsync();
        }


        public async Task<bool> DeleteDepartment(int id)
        {
            var department = await _context.Departments
                .FirstOrDefaultAsync(d => d.Id == id);

            if (department == null)
                return false;

            _context.Departments.Remove(department);

            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<Department> UpdateDepartment(Department department)
        {

            var dept = await _context.Departments.FindAsync(department.Id);
            if (dept == null)
            {
                throw new Exception("department does not exist");
            }
            dept.Name = department.Name;
            await _context.SaveChangesAsync();

            return dept;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeInDepartment(int id)
        {
            return await _context.Departments.Where(d => d.Id == id).SelectMany(d => d.Employees).ToListAsync();

        }

    }
}
