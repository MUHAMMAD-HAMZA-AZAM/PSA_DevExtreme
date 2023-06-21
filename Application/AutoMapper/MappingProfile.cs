using Application.Commands.Product;
using Application.DTOs.Product;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //----- Product Mapping
            CreateMap<AddProductCommand,AddProductDTO>();
            CreateMap<UpdateProductCommand, UpdateProductDTO>();
            CreateMap<UpdateProductDTO, Product>();
        }
    }
}
