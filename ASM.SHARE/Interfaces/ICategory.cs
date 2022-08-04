using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface ICategory
    {
        Task<bool> CreateAsync(Category category);

        Task<bool> UpdateAsync(int id, Category category);

        Task<bool> DeleteAsync(int categoryId);

        Task<Category> GetByIdAsync(int categoryId);

        Task<List<Category>> GetCategoriesAsync();
    }
}
