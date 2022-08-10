using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASM.SHARE.Extensions;
namespace ASM.SHARE.Repositories
{
    public class CategoryRepository : ASM.SHARE.Interfaces.ICategory
    {
        private readonly ShopContext context;

        public CategoryRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            try
            {
                if (category != null)
                {
                    await context.Categories.AddAsync(category);
                    var result = await context.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateManyAsync(List<Category> categories)
        {
            try
            {
                if (categories != null)
                {
                    await context.Categories.AddRangeAsync(categories);
                    var result = await context.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int categoryId)
        {
            try
            {
                Category category = await context.Categories.FindAsync(categoryId);

                if (category != null)
                {
                    context.Categories.Remove(category);
                    var result = await context.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await context.Categories.FindAsync(categoryId);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, Category category)
        {
            try
            {
                if (category != null)
                {
                    category.CategoryId = id;
                    context.Categories.Update(category);
                    var result = await context.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
