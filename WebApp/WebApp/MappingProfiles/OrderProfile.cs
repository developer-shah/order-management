using App.Api.ApiModels;
using App.Api.Application.Order;
using App.Domain;
using AutoMapper;

namespace App.Api.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<CreateOrderCommand, Order>();
            CreateMap<Order, OrderDto>();
        }
    }
}
