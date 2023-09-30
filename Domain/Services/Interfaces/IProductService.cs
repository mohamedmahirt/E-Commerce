using Shopbridge_base.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProduct(int ProductId);

        Task<bool> Create(Product product);

        Task<bool> Update(Product product);

        Task<bool> Delete(int productId);

        Task<List<Product>> Products();

       // List<Product> GetProducts(out int totalRecords, string keyword, int skip, int pageSize, string sortBy, string sortHow);
    }
}
