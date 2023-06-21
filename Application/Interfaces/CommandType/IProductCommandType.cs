using Application.Commands.Product;
using Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.CommandType
{
    public interface IProductCommandType
    {
        Task<bool> AddProduct(AddProductDTO addProductDTO);
        Task<bool> UpdateProduct(UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProduct(int Id);

    }
}
