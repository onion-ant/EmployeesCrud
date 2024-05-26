using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.Models;
using SimpleCrud.Repositories.Interfaces;

namespace SimpleCrud.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiContext _context;
        public EmployeeRepository(ApiContext context)
        {
            _context = context;
        }
        public async Task Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToArrayAsync();
        }
    }
}
