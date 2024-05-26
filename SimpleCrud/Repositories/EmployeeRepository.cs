using Microsoft.EntityFrameworkCore;
using SimpleCrud.Data;
using SimpleCrud.Models;
using SimpleCrud.Repositories.Exceptions;
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

        public async Task<Employee> Get(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new NotFoundException($"{nameof(Employee)} not found");
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employees = await _context.Employees.ToArrayAsync();
            if(employees is null || !employees.Any())
            {
                throw new NotFoundException($"There is no registered {nameof(Employee)}");
            }
            return employees;
        }
    }
}
