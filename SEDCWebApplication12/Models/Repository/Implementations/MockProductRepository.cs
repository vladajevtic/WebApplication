using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models.Repository.Implementations
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;
        public MockProductRepository()
        {
            _productList = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "PICA1",
                    Size = "mala",
                    UnitPrice = 123,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Descriptpion = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                 new Product
                {
                    ProductId = 2,
                    ProductName = "PICA2",
                    Size = "srednja",
                    UnitPrice = 456,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Descriptpion = " has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Picture = "../image/pica.jpg"
                },
                  new Product
                {
                    ProductId = 3,
                    ProductName = "PICA3",
                    Size = "velika",
                    UnitPrice = 789,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Descriptpion = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                  new Product
                {
                    ProductId = 4,
                    ProductName = "PICA4",
                    Size = "mala",
                    UnitPrice = 123,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Descriptpion = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                 new Product
                {
                    ProductId = 5,
                    ProductName = "PICA5",
                    Size = "srednja",
                    UnitPrice = 456,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Descriptpion = " has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Picture = "../image/pica.jpg",
                },
                  new Product
                {
                    ProductId = 6,
                    ProductName = "PICA6",
                    Size = "velika",
                    UnitPrice = 789,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Descriptpion = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                }
            };
        }
        public IEnumerable<Product> GetAllProduct()
        {
            return _productList;
        }

        public Product GetProductById(int id)
        {
            return _productList.Where(x => x.ProductId == id).FirstOrDefault();
        }
    }
}
