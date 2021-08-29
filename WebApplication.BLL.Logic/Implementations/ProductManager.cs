using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;
using WebApplication.DAL.Data.Entities;
using WebApplication.DAL.Data.Interfaces;

namespace WebApplication.BLL.Logic.Implementations
{
    public class ProductManager : IProductManager
    {
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;

        public ProductManager(IProductDAL productDAL, IMapper mapper)
        {
            _productDAL = productDAL;
            _mapper = mapper;
        }
        public ProductDTO Add(ProductDTO product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            _productDAL.Save(productEntity);
            return product;
        }

        public IEnumerable<ProductDTO> GetAllProduct()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll(0, 5));
        }

        public ProductDTO GetProductById(int id)
        {
            return _mapper.Map<ProductDTO>(_productDAL.GetById(id));
        }
    }
}
