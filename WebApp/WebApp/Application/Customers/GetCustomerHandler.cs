using App.Api.ApiModels;
using App.Api.Models;
using App.Domain;
using App.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace App.Api.Application.Customers
{
    public record GetCustomerQuery(int customerId, int size) : IRequest<Result<CustomerDto>>;
    public class GetCustomerHandler(ICustomerRepository<Customer> repository, IMapper mapper) : IRequestHandler<GetCustomerQuery, Result<CustomerDto>>
    {
        public async Task<Result<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await repository.GetCustomerOrders(request.customerId, request.size);

            if (customer == null)
            {
                return Result<CustomerDto>.Failure($"No orders found for customer: {request.customerId}");
            }

            return Result<CustomerDto>.Success(mapper.Map<CustomerDto>(customer));
        }
    }
}
