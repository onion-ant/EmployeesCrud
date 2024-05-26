using SimpleCrud.Models;

namespace SimpleCrud.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task<Employee> Get(int id);
        Task<IEnumerable<Employee>> GetAll();
    }
}
