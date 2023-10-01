using Azure.Core;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> logger;
        private IRepository<Product> repoProduct;

        public ProductService(IRepository<Product> repoProduct)
        {
            this.repoProduct = repoProduct;
        }
        public async Task<bool> Create(Product product)
        {
            try
            {
                await this.repoProduct.Insert(product);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> Delete(int productId)
        {
            try
            {
                await repoProduct.Delete(productId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Product> GetProduct(int ProductId)
        {
            return await repoProduct.GetById(ProductId);
        }

        public async Task<List<Product>> Products()
        {
            return await repoProduct.GetAll();
        }

        public async Task<bool> Update(Product model)
        {
            var response = await repoProduct.Update(model);
            if (response)
                return true;
            else
                return false;
        }
    }
}
