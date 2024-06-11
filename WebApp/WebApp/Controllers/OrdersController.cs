using App.Api.ApiModels;
using App.Api.Application.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Api.Controllers
{
    public class OrdersController : BaseApiController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderDto))]
        public async Task<IActionResult> Create(CreateOrderCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetOrderQuery(id)));
        }
    }
}
