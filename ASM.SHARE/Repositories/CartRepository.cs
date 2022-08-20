using ASM.SHARE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.SHARE.Repositories
{
    public class CartRepository : ASM.SHARE.Interfaces.ICart
    {
        private readonly ShopContext context;

        public CartRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateAsync(Cart cart)
        {
            try
            {
                if (cart != null)
                {
                    await context.Carts.AddAsync(cart);
                    var result = await context.SaveChangesAsync();
                    return result > 0;
                }
                return false;
            }
            catch(Exception e)
            {
                var a = e;
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid cartId)
        {
            try
            {
                Cart cart = await context.Carts.FindAsync(cartId);

                if (cart != null)
                {
                    context.Carts.Remove(cart);
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

        public async Task<List<Cart>> GetListByUserIdAsync(Guid userId)
        {
            return await context.Carts.Where(p => p.UserId == userId).ToListAsync(); ;
        }

        public async Task<Cart> GetByIdAsync(Guid cartId)
        {
            return await context.Carts.FindAsync(cartId);
        }

        public async Task<List<Cart>> GetCartsAsync()
        {
            return await context.Carts.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Cart cart)
        {
            try
            {
                if (cart != null)
                {
                    context.Carts.Update(cart);
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
