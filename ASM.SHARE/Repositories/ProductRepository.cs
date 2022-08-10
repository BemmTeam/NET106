using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                if (product != null)
                {
                    product.CreatedDate = DateTime.UtcNow;
                    await context.Products.AddAsync(product);
                    var result = await context.SaveChangesAsync();
                    return result > 0;

                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }


        public async Task<bool> CreateManyAsync(List<Product> products)
        {
            try
            {
                if (products != null)
                {
                    products.ForEach(item => item.CreatedDate = DateTime.UtcNow);
                    await context.Products.AddRangeAsync(products);
                    var result = await context.SaveChangesAsync();
                    return result > 0;

                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid productId)
        {
            try
            {
                Product product = await context.Products.FindAsync(productId);
                if (product != null)
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
            var a = await context.Products.Include(p => p.Category).ToListAsync();
            return a;
        }

        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2.ToLower();
        }

        public async Task<PagingProductDto> GetProductsAsync(PagingProductDto paging)
        {
            var ListProduct = context.Products;
            var count = await ListProduct.CountAsync();
            paging.PageCount = (int)Math.Ceiling(((double)count / (double)paging.PageSize));

            if (string.IsNullOrEmpty(paging.Search))
            {
                paging.Data = await ListProduct.Include(p => p.Category).OrderByDescending(p => p.CreatedDate).Skip((paging.PageSelected - 1) * paging.PageSize).Take(paging.PageSize).ToListAsync();

            }
            else
            {
                paging.PageSelected = 1;
                paging.Data = ListProduct.Include(p => p.Category).Where(delegate (Product p)
                {
                    if (ConvertToUnSign(p.Name).Contains(ConvertToUnSign(paging.Search)))
                    {
                        return true;
                    }
                    return false;
                })
                .OrderByDescending(p => p.CreatedDate).Skip((paging.PageSelected - 1) * paging.PageSize).Take(paging.PageSize).ToList();

                paging.PageCount = (int)Math.Ceiling(((double)paging.Data.Count / (double)paging.PageSize));

            }


            return paging;
        }


        public async Task<bool> UpdateAsync(Guid id, Product product)
        {
            try
            {
                if (product != null)
                {
                    product.ProductId = id;
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
