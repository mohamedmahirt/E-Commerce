using Shopbridge_base.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategory(int CategoryId);

        Task<bool> Create(Category product);

        Task<bool> Update(Category product);

        Task<bool> Delete(int productId);

        Task<List<Category>> Categorys();
    }
}
