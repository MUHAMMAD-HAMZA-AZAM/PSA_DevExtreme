using Application.DTOs.QueryType.Product;
using Application.Interfaces.QueryType;
using Application.Queries.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandlers.Product
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductDTO>
    {
        private readonly IProductQueryType _productQueryType;
        public GetProductByIdQueryHandler(IProductQueryType productQueryType)
        {
            _productQueryType = productQueryType;
        }
        public async Task<GetProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {      
            return await _productQueryType.GetProductById(request.Id);
        }
    }
}
