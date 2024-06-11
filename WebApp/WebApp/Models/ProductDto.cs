namespace App.Api.Models
{
    public record ProductDto()
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
