using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;


namespace SEDCWebApplication12.Models.Repository.Implementations
{
    public class MockProductRepository : IProductRepository
    {
        private List<ProductDTO> _productList;
        public MockProductRepository()
        {
            _productList = new List<ProductDTO>
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "PICA1",
                    Size = PizzaSize.Medium,
                    Price = 123,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    //Picture = "../image/pica.jpg",
                    //Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                 new ProductDTO
                {
                    Id = 2,
                    Name = "PICA2",
                    Size = PizzaSize.Medium,
                    Price = 456,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    //Description = " has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    //Picture = "../image/pica.jpg"
                },
                  new ProductDTO
                {
                    Id = 3,
                    Name = "PICA3",
                    Size = PizzaSize.Small,
                    Price = 789,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    //Picture = "../image/pica.jpg",
                    //Description = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                  new ProductDTO
                {
                    Id = 4,
                    Name = "PICA4",
                    Size = PizzaSize.Small,
                    Price = 123,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    //Picture = "../image/pica.jpg",
                    //Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                },
                 new ProductDTO
                {
                    Id = 5,
                    Name = "PICA5",
                    Size = PizzaSize.Medium,
                    Price = 456,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    //Description = " has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    //Picture = "../image/pica.jpg",
                },
                  new ProductDTO
                {
                    Id = 6,
                    Name = "PICA6",
                    Size = PizzaSize.Large,
                    Price = 789,
                    IsDiscounted = false,
                    IsActive = true,
                    IsDeleted = false,
                    //Picture = "../image/pica.jpg",
                    //Description = "It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                }
            };
        }
        public IEnumerable<ProductDTO> GetAllProduct()
        {
            return _productList;
        }

        public ProductDTO GetProductById(int id)
        {
            return _productList.Where(x => x.Id == id).FirstOrDefault();
        }

        public ProductDTO AddProduct(ProductDTO product)
        {
            product.Id = _productList.Max(e => e.Id) + 1;
            _productList.Add(product);
            return _productList.Where(x => x.Id == product.Id).FirstOrDefault();
        }

        public ProductDTO DeleteProduct(int id)
        {
            var delete = _productList.ElementAt(id);
            _productList.Remove(delete);
            return delete;
            
        }

        public ProductDTO Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Delete(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        //public Product SaveProduct(Product product)
        //{

        //}
    }
}
