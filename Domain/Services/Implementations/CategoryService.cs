using Microsoft.Extensions.Logging;
using Shopbridge_base.Data.Repository;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Shopbridge_base.Domain.Services.Implementations
{
    public class CategoryService: ICategoryService
    {
        private readonly ILogger<CategoryService> logger;
        private IRepository<Category> repoCategory;

        public CategoryService(IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
        }
        public async Task<bool> Create(Category product)
        {
            try
            {
                await this.repoCategory.Insert(product);
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
                await repoCategory.Delete(productId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Category> GetCategory(int CategoryId)
        {
            return await repoCategory.GetById(CategoryId);
        }

        public async Task<List<Category>> Categorys()
        {
            return await repoCategory.GetAll();
        }

        public async Task<bool> Update(Category model)
        {
            var response = await repoCategory.Update(model);
            if (response)
                return true;
            else
                return false;
        }
    }
}
