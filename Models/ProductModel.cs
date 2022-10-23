using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace efcore3.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
        [ForeignKey("Category")]
        public int Category_id { get; set; }
        public Category? Category { get; set; }
    }
}