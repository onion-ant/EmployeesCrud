using SimpleCrud.Models;

namespace SimpleCrud.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> GetAll();
    }
}
