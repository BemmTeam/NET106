using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.SERVER.HttpRepository
{
    public class UserHttpRepository : ASM.SERVER.HttpInterfaces.IUserHttp
    {
        private readonly HttpClient client;

        public UserHttpRepository(HttpClient client)
        {
            this.client = client;
        }
        public async Task<DataJsonResult> CreateAsync(UserDto userDto)
        {
            var result = await client.PostAsync("https://localhost:5001/api/User", userDto.ToJsonBody());
            return await result.ToDataJsonResultAsync();
        }

        public async Task<DataJsonResult> DeleteAsync(Guid userId)
        {
            var result = await client.DeleteAsync($"https://localhost:5001/api/User?id={userId}");
            return await result.ToDataJsonResultAsync();
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            var user = new User();
            var result = await client.GetAsync($"https://localhost:5001/api/User?id={userId}");

            if (result.IsSuccessStatusCode)
            {
                var _dataResponse = await result.ToDataJsonResultAsync();
                if (_dataResponse.IsSuccess)
                {
                    user = JsonConvert.DeserializeObject<User>(_dataResponse.Data.ToString());
                }
            }

            return user;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();
            var result = await client.GetAsync("https://localhost:5001/api/User");

            if (result.IsSuccessStatusCode)
            {
                var _dataResponse = await result.ToDataJsonResultAsync();
                if (_dataResponse.IsSuccess)
                {
                    users = JsonConvert.DeserializeObject<List<User>>(_dataResponse.Data.ToString());
                }
            }

            return users;
        }

        public async Task<DataJsonResult> UpdateAsync(Guid id, UserDto userDto)
        {
            var result = await client.PutAsync($"https://localhost:5001/api/user/?id={id}", userDto.ToJsonBody());
            if (result.IsSuccessStatusCode)
            {
                return await result.ToDataJsonResultAsync();
            }
            return new DataJsonResult { IsSuccess = false, Message = "Dữ liệu không đúng định dạng" };
        }
    }
}
