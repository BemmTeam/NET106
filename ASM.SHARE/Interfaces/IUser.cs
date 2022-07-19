using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface IUser
    {

        Task<bool> CreateAsync(User user);

        Task<bool> UpdateAsync(User user); 

        Task<bool> DeleteAsync(Guid userId);

        Task<User> LoginAsync(LoginModel model);

        Task<User> RegisterAsync(RegisterModel model);


        Task<List<User>> GetUsersAsync();

        Task<User> GetByIdAsync(Guid id);

        
    }
}
