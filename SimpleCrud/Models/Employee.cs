using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Photo { get; private set; }

        public Employee(string name, int age, string photo)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Age = age;
            Photo = photo;
        }
    }
}
