using Application.DTOs.QueryType.Product;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.QueryType
{
    public interface IProductQueryType
    {
        Task<Response> GetAllProducts(PagingParams pagingParams);
        Task<GetProductDTO> GetProductById(int Id);
    }
}
