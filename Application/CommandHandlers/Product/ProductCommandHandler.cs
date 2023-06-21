using Application.Commands.Product;
using Application.DTOs.Product;
using Application.Interfaces.CommandType;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommandHandlers.Product
{
    public class ProductCommandHandler : IRequestHandler<AddProductCommand, bool>,
                                         IRequestHandler<UpdateProductCommand, bool>,
                                         IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductCommandType _productCommandType;
        private readonly IMapper _mapper;
        public ProductCommandHandler(IProductCommandType productCommandType, IMapper mapper)
        {
            _productCommandType = productCommandType;
            _mapper = mapper;
        }
        public async Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<AddProductDTO>(request);//we map the incoming object of type request to type AddProductDTO
            return await _productCommandType.AddProduct(product);
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<UpdateProductDTO>(request);//we map the incoming object of type request to type AddProductDTO
            return await _productCommandType.UpdateProduct(product);
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _productCommandType.DeleteProduct(request.Id);
        }
    }
}
