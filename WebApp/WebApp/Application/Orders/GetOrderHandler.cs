using App.Api.ApiModels;
using App.Domain;
using App.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace App.Api.Application.Order
{
    public record GetOrderQuery(Guid id) : IRequest<Result<OrderDto>>;
    public class GetOrderHandler(IRepository<App.Domain.Order> repository, IMapper mapper) : IRequestHandler<GetOrderQuery, Result<OrderDto>>
    {
        public async Task<Result<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            //I'm ignoring paging, error handling etc for this demo project
            var order = await repository.GetAsync(request.id);

            if (order == null)
            {
                return Result<OrderDto>.Failure($"No order found with Id: {request.id}");
            }

            return Result<OrderDto>.Success(mapper.Map<OrderDto>(order));
        }
    }
}
