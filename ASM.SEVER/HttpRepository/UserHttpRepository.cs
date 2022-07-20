using ASM.SHARE.Dtos;
using ASM.SHARE.Entities;
using ASM.SHARE.Extensions;
using ASM.SHARE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ASM.SEVER.HttpRepository
{
    public class UserHttpRepository : ASM.SEVER.HttpInterfaces.IUserHttp
    {
        private readonly HttpClient client;

        public UserHttpRepository(HttpClient client)
        {
            this.client = client;
        }
        public Task<DataJsonResult> CreateAsync(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<DataJsonResult> DeleteAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
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

        public Task<DataJsonResult> UpdateAsync(Guid id, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
