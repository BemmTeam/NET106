﻿using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASM.SHARE.Interfaces
{
    public interface IUser
    {

        Task<bool> CreateAsync(UserDto user);

        Task<bool> UpdateAsync(Guid id, UserDto user);

        Task<bool> DeleteAsync(Guid userId);

        Task<bool> CheckValidUserAsync(UserDto user);


        Task<User> LoginAsync(LoginModel model);

        Task<User> RegisterAsync(RegisterModel model);


        Task<List<User>> GetUsersAsync();

        Task<User> GetByIdAsync(Guid id);


    }
}
