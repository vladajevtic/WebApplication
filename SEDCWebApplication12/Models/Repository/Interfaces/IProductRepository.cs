using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;

namespace SEDCWebApplication12.Models.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetAllProduct();

        ProductDTO GetProductById(int id);

        ProductDTO AddProduct(ProductDTO product);

        ProductDTO Update(int id, ProductDTO product);

    }
}
