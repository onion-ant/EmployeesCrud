namespace SimpleCrud.DTOs
{
    public class POSTEmployeeDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public IFormFile Photo { get; set; }
    }
}
