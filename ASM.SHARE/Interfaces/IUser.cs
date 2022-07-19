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

        Task<bool> Create(User user);

        Task<bool> Update(User user); 

        Task<bool> Delete(Guid userId);

        Task<User> Login(LoginModel model);

        Task<User> Register(RegisterModel model);


        Task<List<User>> GetUsers();

        Task<User> GetById(Guid id);

        
    }
}
