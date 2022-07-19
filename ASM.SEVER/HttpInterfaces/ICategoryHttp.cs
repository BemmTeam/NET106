using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SEVER.HttpInterfaces
{
    public interface ICategoryHttp
    {
        Task<bool> CreateAsync(CategoryDto category);

        Task<bool> UpdateAsync(int id, CategoryDto category);

        Task<bool> DeleteAsync(int categoryId);

        Task<Category> GetByIdAsync(int categoryId);

        Task<List<Category>> GetCategoriesAsync();
    }
}
