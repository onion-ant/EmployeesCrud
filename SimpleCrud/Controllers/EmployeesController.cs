using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTOs;
using SimpleCrud.DTOs.Mapping;
using SimpleCrud.Repositories.Interfaces;

namespace SimpleCrud.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeRepository.GetAll();
            var employeesDTO = employees.ToArrayEmployeeDTO();
            return Ok(employeesDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] POSTEmployeeDTO employeeDTO)
        {
            var filePath = Path.Combine("Storage", employeeDTO.Photo.FileName);
            await _employeeRepository.Add(employeeDTO.ToEmployee());
            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeDTO.Photo.CopyTo(fileStream);
            return Ok();
        }
    }
}
