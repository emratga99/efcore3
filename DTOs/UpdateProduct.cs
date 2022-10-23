namespace efcore3.DTOs
{
    public class UpdateProduct
    {
        public string Name { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
        public int Category_id { get; set; }
    }
}