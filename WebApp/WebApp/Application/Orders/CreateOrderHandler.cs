using App.Api.ApiModels;
using App.Domain.Interfaces.Repositories;
using MediatR;
using App.Domain;
using AutoMapper;
namespace App.Api.Application.Order
{
    public record CreateOrderCommand() : IRequest<Result<OrderDto>>
    {
        public int CustomerId { get; set; }
        public ICollection<int> ProductIds { get; set; }
    }
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
    {
        private readonly ILogger<CreateOrderHandler> _logger;
        private readonly IRepository<Domain.Order> _repository;
        private readonly IMapper _mapper;

        public CreateOrderHandler(ILogger<CreateOrderHandler> logger, IRepository<App.Domain.Order> repository, IMapper mapper)
        {
            
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //ignoring the product products (and its validation) for the demo
            var order = await _repository.AddAsync(new Domain.Order { CustomerId = request.CustomerId, Id = Guid.NewGuid(), OrderDate = DateTime.UtcNow});

            //ignoring error handling for now
            return Result<OrderDto>.Success(_mapper.Map<OrderDto>(order));
        }
    }
}
