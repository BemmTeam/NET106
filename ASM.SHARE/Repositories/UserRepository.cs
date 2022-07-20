using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Repositories
{
    public class UserRepository : ASM.SHARE.Interfaces.IUser
    {
        private readonly ShopContext context;

        public UserRepository(ShopContext _context)
        {
            context = _context;
        }

        private string encrytion(string password)
        {
            var sha  = SHA256.Create();
            var asBytes = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asBytes);

            return Convert.ToBase64String(hashedPassword);
        }

        public async Task<bool> CreateAsync(UserDto userDto)
        {
            try
            {
                if (userDto != null)
                {
                    userDto.Password = encrytion(userDto.Password);
                    await context.Users.AddAsync(userDto.ToUser());
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

        public async Task<bool> DeleteAsync(Guid userId)
        {
            try
            {
                User user = await context.Users.FindAsync(userId);
                if(user != null)
                {
                    if(!user.IsAdmin)
                    {
                        context.Remove(user);
                        var result = await context.SaveChangesAsync();
                        return result > 0;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> LoginAsync(LoginModel model)
        {
            if(model != null)
            {
                var pass = encrytion(model.Password);
                User user = await context.Users.Where(u => u.UserName.ToLower() == model.UserName.ToLower() 
                && u.Password == pass).FirstOrDefaultAsync();
                return user;
            }
            return null;
        }

        public async Task<bool> UpdateAsync(Guid id,UserDto userDto)
        {
            try
            {
                if(userDto != null)
                {
                    userDto.Password = encrytion(userDto.Password);
                    context.Users.Update(userDto.ToUser(id));
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

        public async Task<User> RegisterAsync(RegisterModel model)
        {
            try
            {
                var asd = context.Users.ToList();
                var pass = encrytion(model.Password);
                User user = new() {  Address = model.HomeAddress , FullName = model.FullName  , UserName = model.UserName , Password = pass};
                await context.Users.AddAsync(user);
                var result = await context.SaveChangesAsync();
                if (result > 0)
                    return user;
                return null;
            }
            catch { return null; }
        }

        public async Task<bool> CheckValidUserAsync(UserDto userDto)
        {
            return await context.Users.AnyAsync(u => u.UserName == userDto.UserName || u.Email == userDto.Email);
        }
    }
}
