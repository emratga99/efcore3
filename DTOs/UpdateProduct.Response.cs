namespace efcore3.DTOs
{
    public class UpdateProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
        public int Category_id { get; set; }
    }
}