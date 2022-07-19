﻿using ASM.SHARE.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Repositories
{
    public class CartDetailRepository : ASM.SHARE.Interfaces.ICartDetail
    {
        private readonly ShopContext context;

        public CartDetailRepository(ShopContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(CartDetail cartDetail)
        {
            try
            {
                if(cartDetail != null)
                {
                    await context.CartDetails.AddAsync(cartDetail);
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

        public async Task<bool> Delete(Guid cartDetailId)
        {
            try
            {
                CartDetail cart = await context.CartDetails.FindAsync(cartDetailId);

                if(cart != null)
                {
                    context.CartDetails.Remove(cart);
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

        public async Task<CartDetail> GetById(Guid cartId)
        {
            return await context.CartDetails.FindAsync(cartId);
        }

        public async Task<List<CartDetail>> GetCartDetails()
        {
            return await context.CartDetails.ToListAsync();
        }

        public async Task<bool> Update(CartDetail cartDetail)
        {
           try
            {
                if(cartDetail != null)
                {
                    context.CartDetails.Update(cartDetail);
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