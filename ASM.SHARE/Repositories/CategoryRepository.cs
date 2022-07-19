using ASM.SHARE.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Repositories
{
    public class CategoryRepository : ASM.SHARE.Interfaces.ICategory
    {
        private readonly ShopContext context;

        public CategoryRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(Category category)
        {
            try
            {
                if(category != null)
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

        public async Task<bool> Delete(int categoryId)
        {
            try
            {
                Category category = await context.Categories.FindAsync(categoryId);

                if(category != null)
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

        public async Task<Category> GetById(int categoryId)
        {
            return await context.Categories.FindAsync(categoryId);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<bool> Update(Category category)
        {
           try
            {
                if(category != null)
                {
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
