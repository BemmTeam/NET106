using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SEVER.HttpInterfaces
{
    public interface IUserHttp
    {
        Task<DataJsonResult> CreateAsync(UserDto userDto);

        Task<DataJsonResult> UpdateAsync(Guid id, UserDto userDto);

        Task<DataJsonResult> DeleteAsync(Guid userId);

        Task<User> GetByIdAsync(Guid userId);

        Task<List<User>> GetUsersAsync();
    }
}
