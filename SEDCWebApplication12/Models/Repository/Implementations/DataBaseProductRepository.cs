using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;

namespace SEDCWebApplication12.Models.Repository.Implementations
{
    public class DataBaseProductRepository : IProductRepository
    {
        private readonly IProductManager _productManager;

        public DataBaseProductRepository(IProductManager productManager)
        {
            _productManager = productManager;
        }
        public ProductDTO AddProduct(ProductDTO product)
        {
            return _productManager.Add(product);
        }

        public IEnumerable<ProductDTO> GetAllProduct()
        {
            return _productManager.GetAllProduct();
        }

        public ProductDTO GetProductById(int id)
        {
            try
            {
                return _productManager.GetProductById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public ProductDTO Update(ProductDTO product)
        {
            return _productManager.Update(product);
        }
    }
}
