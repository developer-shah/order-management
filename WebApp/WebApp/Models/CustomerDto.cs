using App.Api.ApiModels;

namespace App.Api.Models
{
    public record CustomerDto()
    {
        public int Id { get; set; }
        public ICollection<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}
