﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProduct();

        Product GetProductById(int id);

        Product AddProduct(Product product);

        Product DeleteProduct(int id, Product product);

        //Product SaveProduct(Product product);
    }
}
