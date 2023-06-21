using Application.DTOs.Product;
using Application.Interfaces.CommandType;
using AutoMapper;
using Azure;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Persistence.Database;
using Shared.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands
{
    public class ProductCommandType : IProductCommandType
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ProductCommandType(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> AddProduct(AddProductDTO addProductDTO)
        {
            var product = new Product
            {
                Name = addProductDTO.Name,
                Barcode = addProductDTO.Barcode,
                Description = addProductDTO.Description,
                Rate = addProductDTO.Rate
            };
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            var product = await _context.Products.FindAsync(updateProductDTO.Id);
            _mapper.Map(updateProductDTO, product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product == null) return false;
            product.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
