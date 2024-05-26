using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.DTOs;
using SimpleCrud.DTOs.Mapping;
using SimpleCrud.Models;
using SimpleCrud.Repositories.Exceptions;
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
            try
            {
                var employees = await _employeeRepository.GetAll();
                var employeesDTO = employees.ToArrayEmployeeDTO();
                return Ok(employeesDTO);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadPhoto(int id)
        {
            try
            {
                var employee = await _employeeRepository.Get(id);
                if (employee.Photo != null)
                {
                    var dataBytes = System.IO.File.ReadAllBytes(employee.ToEmployeeDTO().Photo);
                    return File(dataBytes, "image/png");
                }
                return NotFound($"This {nameof(Employee)} does not have a photo");
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] POSTEmployeeDTO employeeDTO)
        {
            await _employeeRepository.Add(employeeDTO.ToEmployee());
            if (employeeDTO.Photo != null)
            {
                var filePath = Path.Combine("Storage", employeeDTO.Photo.FileName);
                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                employeeDTO.Photo.CopyTo(fileStream);
            }
            return Ok();
        }
    }
}
