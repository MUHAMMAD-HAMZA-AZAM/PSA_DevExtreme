using Application.DTOs.QueryType.Product;
using Application.Interfaces.QueryType;
using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries
{
    public class ProductQueryType : BaseQueryType, IProductQueryType
    {
        private readonly DataContext _dataContext;
        public ProductQueryType(IDbConnection dbConnection, DataContext dataContext) : base(dbConnection)
        {
            _dataContext = dataContext;
          
        }

        public async Task<Response> GetAllProducts(PagingParams pagingParams)
        {
            Response response = new Response();
            DynamicParameters param = new DynamicParameters();
            param.Add("@PageSize",pagingParams.PageSize);
            param.Add("@PageNumber", pagingParams.PageNumber);
            param.Add("@TextToSearch", pagingParams.TextToSearch);
            param.Add("@SortOrder", pagingParams.SortOrder);
            param.Add("@SortColumn", pagingParams.SortColumn);
            response.ResultData = await _db.QueryAsync<GetProductDTO>("GetAllProducts",param,commandType: CommandType.StoredProcedure);
            response.StatusCode = Status.Success;
            return response;
        }

        public  async Task<GetProductDTO> GetProductById(int Id)
        {
            return await _db.QueryFirstOrDefaultAsync<GetProductDTO>("SELECT * FROM Products99 WHERE @Id = Id ",new { Id = Id});
        }
    }
}
