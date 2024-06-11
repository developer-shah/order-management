using App.Api.Application.Products;
using App.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Api.Controllers;

namespace App.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ICollection<ProductDto>))]
        public async Task<IActionResult> Get()
        {
            return HandleResult(await Mediator.Send(new GetProductQuery()));
        }
    }
}
