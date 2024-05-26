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
        [HttpPost]
        public async Task<IActionResult> Add(EmployeeDTO employeeDTO)
        {
            await _employeeRepository.Add(employeeDTO.ToEmployee());
            return Ok();
        }
    }
}
