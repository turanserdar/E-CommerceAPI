using ECommerceAPI.Application.Abstractions;
using ECommerceAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new()
            {
                new() { id=Guid.NewGuid(),Name="Product1",Price=100,Stock=100 },
                 new() { id=Guid.NewGuid(),Name="Product2",Price=200,Stock=200 },
                  new() { id=Guid.NewGuid(),Name="Product3",Price=300,Stock=300 },
                   new() { id=Guid.NewGuid(),Name="Product4",Price=400,Stock=400 },
                    new() { id=Guid.NewGuid(),Name="Product5",Price=500,Stock=1000 },
            };


    }
}
