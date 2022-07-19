using ASM.SHARE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Repositories
{
    public class ProductRepository : ASM.SHARE.Interfaces.IProduct
    {
        private readonly ShopContext context;

        public ProductRepository(ShopContext _shopContext)
        {
            context = _shopContext;
        }
        

        public async Task<bool> CreateAsync(Product product)
        {
            try
            {
                if(product != null)
                {
                    await context.Products.AddAsync(product);
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

        public async Task<bool> DeleteAsync(Guid productId)
        {
            try
            {
                Product product = await context.Products.FindAsync(productId);
                if(product != null)
                {
                    context.Products.Remove(product);
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

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await context.Products.FindAsync(productId); 
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            try
            {
                if(product != null)
                {
                    context.Products.Update(product);
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
