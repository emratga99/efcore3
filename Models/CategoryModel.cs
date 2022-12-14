using System.ComponentModel.DataAnnotations;

namespace efcore3.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Product> Products { get; set; } = null!;
    }
}