using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Product
{
    public class ProductCommand
    {
        public string? Name { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }
        public decimal Rate { get; set; }
    }
}
