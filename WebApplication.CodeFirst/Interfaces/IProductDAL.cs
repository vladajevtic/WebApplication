using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.CodeFirst.Interfaces
{
    public interface IProductDAL
    {
        void Save(Product item);
        void Update(int id, Product item);

        Product GetById(int id);

        List<Product> GetAll(int skip, int take);
    }
}
