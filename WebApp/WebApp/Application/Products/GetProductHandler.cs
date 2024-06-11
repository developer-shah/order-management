using App.Api.ApiModels;
using App.Api.Models;
using App.Domain;
using App.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace App.Api.Application.Products
{
    public record GetProductQuery() : IRequest<Result<ICollection<ProductDto>>>;
    public class GetProductHandler(IRepository<Product> repository, IMapper mapper) : IRequestHandler<GetProductQuery, Result<ICollection<ProductDto>>>
    {
        public async Task<Result<ICollection<ProductDto>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.AllAsync();

            if (products is null)
            {
                return Result<ICollection<ProductDto>>.Failure("No products found");
            }
            return Result<ICollection<ProductDto>>.Success(mapper.Map<ICollection<ProductDto>>(products));
        }
    }
}
