using MediatR;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Product
{
    public class GetAllProductsQuery : IRequest<Response>
    {
        public PagingParams _pagingParams { get; set; }
        public GetAllProductsQuery( PagingParams pagingParams)
        {
            _pagingParams = pagingParams;
        }
    }
}
