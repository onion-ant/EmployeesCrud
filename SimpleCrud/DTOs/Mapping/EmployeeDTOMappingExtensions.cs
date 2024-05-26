using SimpleCrud.Models;

namespace SimpleCrud.DTOs.Mapping
{
    public static class EmployeeDTOMappingExtensions
    {
        public static EmployeeDTO? ToEmployeeDTO(this Employee employee)
        {
            if (employee == null)
            {
                return null;
            }
            return new EmployeeDTO()
            {
                Age = employee.Age,
                Name = employee.Name,
            };
        }
        public static IEnumerable<EmployeeDTO>? ToArrayEmployeeDTO(this IEnumerable<Employee> employeeEnumreable)
        {
            if (employeeEnumreable is null || !employeeEnumreable.Any())
            {
                return [];
            }
            return employeeEnumreable.Select(employee => employee.ToEmployeeDTO()).ToArray();
        }
        public static IEnumerable<EmployeeDTO>? ToListEmployeeDTO(this IEnumerable<Employee> employeeEnumreable)
        {
            if (employeeEnumreable is null || !employeeEnumreable.Any())
            {
                return new List<EmployeeDTO>();
            }
            return employeeEnumreable.Select(employee => employee.ToEmployeeDTO()).ToList();
        }
        public static Employee? ToEmployee(this EmployeeDTO employeeDTO)
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
        public static IEnumerable<Employee>? ToArrayEmployee(this IEnumerable<EmployeeDTO> employeeDTOEnumreable)
        {
            if (employeeDTOEnumreable is null || !employeeDTOEnumreable.Any())
            {
                return [];
            }
            return employeeDTOEnumreable.Select(dto => dto.ToEmployee()).ToArray();
        }
        public static IEnumerable<Employee>? ToListEmployee(this IEnumerable<EmployeeDTO> employeeDTOEnumreable)
        {
            if (employeeDTOEnumreable is null || !employeeDTOEnumreable.Any())
            {
                return new List<Employee>();
            }
            return employeeDTOEnumreable.Select(dto => dto.ToEmployee()).ToList();
        }
    }
}
