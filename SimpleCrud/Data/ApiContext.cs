using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;

namespace SimpleCrud.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
