using ASM.SHARE;
using ASM.SHARE.Interfaces;
using ASM.SHARE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IUser userRepository;

        public TokenController(IConfiguration configuration, IUser userRepository)
        {
            this.configuration = configuration;
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> New(LoginModel userData)
        {
            System.Console.WriteLine(userData.UserName);
           
            if (userData != null && userData.UserName != null && userData.Password != null)
            {
                var user = await userRepository.LoginAsync(userData);
                if (user != null)
                {
                    // create clamis
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub , configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                        new Claim(ClaimTypes.Role , user.IsAdmin ? "Admin" : "Customer"),
                        new Claim("Id" , user.UserId.ToString()),
                        new Claim("FullName" , user.FullName.ToString()),
                        new Claim("UserName" , user.UserName.ToString()),

                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(configuration["Jwt:Issuer"]
                    , configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1)
                    , signingCredentials: signIn
                    );

                    return Ok(new { Success = true, Message = "Đăng nhập thành công", Token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return Ok(new { Success = false, Message = "Tài khoản hoặc mật khẩu không đúng" });
                }
            }
            return Ok(new { Success = false, Message = "Thiếu thông tin đăng nhập" });

        }



    }
}
