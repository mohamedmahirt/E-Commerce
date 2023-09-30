﻿using Azure.Core;
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
            Product product =await repoProduct.GetById(model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Description = model.Description;
                product.CategoryId = model.CategoryId;
                product.Caption = model.Caption;
                product.ProductCode = model.ProductCode;
                product.Color = model.Color;
                product.IsActive = model.IsActive;
                product.SaleAmount = model.SaleAmount;
                product.IsFeatured = model.IsFeatured;
                product.PurchaseAmount = model.PurchaseAmount;
                product.ModifiedDate = DateTime.UtcNow;
                await repoProduct.Update(product);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
