namespace Store.Application.DTOs
{
    public class ProductWithCategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
    }
}
