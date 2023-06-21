using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Product
{
    public class ProductDTO
    {
        public string? Name { get; set; }
        public string? Barcode { get; set; }
        public string? Description { get; set; }
        public decimal Rate { get; set; }
    }

    public class AddProductDTO : ProductDTO
    {

    }

    public class UpdateProductDTO : ProductDTO
    {
        public int Id { get; set; }
    }
}
