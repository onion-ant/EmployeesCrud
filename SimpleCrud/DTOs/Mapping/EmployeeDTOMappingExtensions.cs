using SimpleCrud.Models;

namespace SimpleCrud.DTOs.Mapping
{
    public static class EmployeeDTOMappingExtensions
    {
        public static GETEmployeeDTO? ToEmployeeDTO(this Employee employee)
        {
            if (employee == null)
            {
                return null;
            }
            return new GETEmployeeDTO()
            {
                Id = employee.Id,
                Age = employee.Age,
                Name = employee.Name,
                Photo = employee.Photo
            };
        }
        public static IEnumerable<GETEmployeeDTO>? ToArrayEmployeeDTO(this IEnumerable<Employee> employeeEnumreable)
        {
            if (employeeEnumreable is null || !employeeEnumreable.Any())
            {
                return [];
            }
            return employeeEnumreable.Select(employee => employee.ToEmployeeDTO()).ToArray();
        }
        public static IEnumerable<GETEmployeeDTO>? ToListEmployeeDTO(this IEnumerable<Employee> employeeEnumreable)
        {
            if (employeeEnumreable is null || !employeeEnumreable.Any())
            {
                return new List<GETEmployeeDTO>();
            }
            return employeeEnumreable.Select(employee => employee.ToEmployeeDTO()).ToList();
        }
        public static Employee? ToEmployee(this POSTEmployeeDTO employeeDTO)
        {
            if(employeeDTO == null)
            {
                return null;
            }
            return new Employee()
            {
                Name = employeeDTO.Name,
                Age = employeeDTO.Age,
                Photo = null
            };
        }
        public static IEnumerable<Employee>? ToArrayEmployee(this IEnumerable<POSTEmployeeDTO> employeeDTOEnumreable)
        {
            if (employeeDTOEnumreable is null || !employeeDTOEnumreable.Any())
            {
                return [];
            }
            return employeeDTOEnumreable.Select(dto => dto.ToEmployee()).ToArray();
        }
        public static IEnumerable<Employee>? ToListEmployee(this IEnumerable<POSTEmployeeDTO> employeeDTOEnumreable)
        {
            if (employeeDTOEnumreable is null || !employeeDTOEnumreable.Any())
            {
                return new List<Employee>();
            }
            return employeeDTOEnumreable.Select(dto => dto.ToEmployee()).ToList();
        }
    }
}
