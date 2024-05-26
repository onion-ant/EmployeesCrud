using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Models;

namespace SimpleCrud.Data
{
    public class ApiContext : IdentityDbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ApiContext(DbContextOptions options) : base(options)
        {
        }
    }
}
