using App.Api.Application.Customers;
using App.Api.Application.Order;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Controllers;

namespace App.Api.Controllers
{
    public class CustomersController : BaseApiController
    {
        [HttpGet("{customerId:int}/orders")]
        public async Task<IActionResult> GetCustomerOrders(int customerId, int size)
        {
            return HandleResult(await Mediator.Send(new GetCustomerQuery(customerId, size)));
        }
    }
}
