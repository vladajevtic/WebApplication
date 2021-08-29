using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Models;

namespace WebApplication.BLL.Logic.Interfaces
{
    public interface IProductManager
    {
        IEnumerable<ProductDTO> GetAllProduct();
        ProductDTO GetProductById(int id);
        ProductDTO Add(ProductDTO employee);
    }
}
