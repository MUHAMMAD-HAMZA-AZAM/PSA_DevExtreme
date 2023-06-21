using Application.Interfaces.QueryType;
using Application.Queries.Product;
using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.QueryHandlers.Product
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response>
    {
        private readonly IProductQueryType _productQueryType;
        public GetAllProductsQueryHandler(IProductQueryType productQueryType)
        {
            _productQueryType = productQueryType;
        }
        public async Task<Response> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productQueryType.GetAllProducts(request._pagingParams);
        }
    }
}
