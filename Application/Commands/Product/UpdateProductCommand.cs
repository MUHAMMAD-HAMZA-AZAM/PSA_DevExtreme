﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public class UpdateProductCommand : ProductCommand , IRequest<bool>
    {
        public int Id { get; set; }
    }
}
