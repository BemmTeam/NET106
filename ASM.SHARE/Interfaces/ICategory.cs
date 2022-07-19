using ASM.SHARE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface ICategory
    {
        Task<bool> Create(Category category);

        Task<bool> Update(Category category);

        Task<bool> Delete(int categoryId);

        Task<Category> GetById(int categoryId);

        Task<List<Category>> GetCategories();
    }
}
