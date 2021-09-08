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
            productEntity.EntityState = (EntityStateEnum)1;
            _productDAL.Save(productEntity);
            product = _mapper.Map<ProductDTO>(productEntity);

            return product;
        }

        public ProductDTO Delete(ProductDTO product)
        {
            Product product1 = _mapper.Map<Product>(product);
            if (product1.IsDeleted == true)
            {
                return product;
            }
            else
            {
                var delete = 3;
                product1.EntityState = (EntityStateEnum)delete;
                _productDAL.Save(product1);

                return _mapper.Map<ProductDTO>(product1);
            }
        }

        public IEnumerable<ProductDTO> GetAllProduct()
        {
            return _mapper.Map<List<ProductDTO>>(_productDAL.GetAll(0, 50));
        }

        public ProductDTO GetProductById(int id)
        {
            try
            {
                Product product = _productDAL.GetById(id);
                if (product == null)
                {
                    throw new Exception($"Product with {id} id not found");
                }
                return _mapper.Map<ProductDTO>(_productDAL.GetById(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ProductDTO Update(ProductDTO product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            _productDAL.Save(productEntity);
            product = _mapper.Map<ProductDTO>(productEntity);

            return product;

        }
        //public ProductDTO Delete(ProductDTO product)
        //{
        //    Product productEntity = _mapper.Map<Product>(product);
        //    _productDAL.Delete
        //    product = _mapper.Map<ProductDTO>(productEntity);

        //    return product;

        //}
    }
}
