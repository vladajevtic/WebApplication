using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DAL.Data.Entities;

namespace WebApplication.DAL.Data.Interfaces
{
    public interface IProductDAL
    {
        void Save(Product item);

        Product GetById(int id);

        List<Product> GetAll(int skip, int take);
    }
}
