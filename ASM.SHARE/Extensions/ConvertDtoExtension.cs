using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Extensions
{
    public static class ConvertDto
    {
        public static Category ToCategory(this CategoryDto dto, int? id = null)
        {
            if(id != null)
            {
                return new Category
                {
                    CategoryId = id.Value,
                    Name = dto.Name,
                    Desc = dto.Desc,
                };
            }
            return new Category
            {
                Name = dto.Name,
                Desc = dto.Desc,
            };
        }

        public static User ToUser(this UserDto dto, Guid? id = null)
        {
            if (id != null)
            {
                return new User
                {
                    UserId = (Guid)id,
                    FullName = dto.FullName, 
                    UserName = dto.UserName,
                    Address = dto.Address,
                    Email = dto.Email, 
                    Password = dto.Password,
                    IsAdmin = dto.IsAdmin,
                };
            }
            return new User
            {
                FullName = dto.FullName,
                UserName = dto.UserName,
                Address = dto.Address,
                Email = dto.Email,
                Password = dto.Password,
                IsAdmin = dto.IsAdmin,

            };
        }


        public static Product ToProduct(this ProductDto dto, Guid? id = null)
        {
            Console.WriteLine("day la dia chi: " + dto.Address);
            if (id != null)
            {
                return new Product
                {
                    ProductId = (Guid)id,
                    Name = dto.Name,
                    Quantity = dto.Quantity,
                    Price = dto.Price,
                    Desc = dto.Desc,
                    ImageUrl = dto.ImageUrl,
                    Address = dto.Address,
                    CategoryId = dto.CategoryId,
                    QrCodeUrl = dto.QrCodeUrl
                };
            }
            return new Product
            {
                Name = dto.Name,
                Quantity = dto.Quantity,
                Price = dto.Price,
                Desc = dto.Desc,
                ImageUrl = dto.ImageUrl,
                Address = dto.Address,
                CategoryId = dto.CategoryId,
                QrCodeUrl = dto.QrCodeUrl
            };
        }
    }
}
