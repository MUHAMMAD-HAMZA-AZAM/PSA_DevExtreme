using Application.Commands.Product;
using Application.DTOs.QueryType.Product;
using Application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Wrappers;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        public ProductController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<GetProductDTO> GetProduct(int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetProductByIdQuery(id), cancellationToken);
        }
        [HttpGet("GetProducts")]
        public async Task<Response> GetProducts([FromQuery] PagingParams pagingParams, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new GetAllProductsQuery(pagingParams), cancellationToken);
        }

        [HttpPost("AddProduct")]
        public async Task<bool> AddProduct([FromBody] AddProductCommand cmd, CancellationToken cancellationToken)
        {
            return await Mediator.Send(cmd, cancellationToken);
        }
        [HttpPut("UpdateProduct/{id}")]
        public async Task<bool> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductCommand cmd, CancellationToken cancellationToken)
        {
            cmd.Id = id;
            return await Mediator.Send(cmd, cancellationToken);
        }
        [HttpDelete("DeleteProduct/{id}")]
        public async Task<bool> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new DeleteProductCommand(id), cancellationToken);
        }
    }
}
