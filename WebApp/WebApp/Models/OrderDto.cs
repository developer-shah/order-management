namespace App.Api.ApiModels
{
    public record OrderDto()
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
