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
    }
}
