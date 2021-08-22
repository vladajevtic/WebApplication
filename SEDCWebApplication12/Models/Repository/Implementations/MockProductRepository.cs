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
                    Size = Size.Large,
                    UnitPrice = 123,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                 new Product
                {
                    ProductId = 2,
                    ProductName = "PICA2",
                    Size = Size.Medium,
                    UnitPrice = 456,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Description = " has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Picture = "../image/pica.jpg"
                },
                  new Product
                {
                    ProductId = 3,
                    ProductName = "PICA3",
                    Size = Size.Small,
                    UnitPrice = 789,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Description = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                  new Product
                {
                    ProductId = 4,
                    ProductName = "PICA4",
                    Size = Size.Small,
                    UnitPrice = 123,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                 new Product
                {
                    ProductId = 5,
                    ProductName = "PICA5",
                    Size = Size.Medium,
                    UnitPrice = 456,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Description = " has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Picture = "../image/pica.jpg",
                },
                  new Product
                {
                    ProductId = 6,
                    ProductName = "PICA6",
                    Size = Size.Large,
                    UnitPrice = 789,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    Picture = "../image/pica.jpg",
                    Description = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
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

        public Product AddProduct(Product product)
        {
            product.ProductId = _productList.Max(e => e.ProductId) + 1;
            _productList.Add(product);
            return _productList.Where(x => x.ProductId == product.ProductId).FirstOrDefault();
        }
    }
}
