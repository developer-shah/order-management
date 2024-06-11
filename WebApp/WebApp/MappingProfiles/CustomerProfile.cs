using App.Api.Models;
using App.Domain;
using AutoMapper;

namespace App.Api.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {           
            CreateMap<Customer, CustomerDto>();
        }
    }
}
