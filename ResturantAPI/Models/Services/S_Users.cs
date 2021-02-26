using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public class S_Users : I_Users<Users>
    {
        readonly ResturantDbContext _resturantDb;
        private static IConfiguration _config;

        public S_Users(ResturantDbContext context, IConfiguration config)
        {
            _resturantDb = context;
            _config = config;
        }
       
        public Dictionary<string, object> Login(LoginDTO loginDTO)
        {
            var result = new Dictionary<string, object>();

            try
            {
                var user = _resturantDb.Users.Where(w => w.Username == loginDTO.Username && w.Password == Users.ChangeSha512(loginDTO.Password)).FirstOrDefault();
                if (user == null)
                {
                    result.Add("status", 400);
                    result.Add("message", "Sai tên tài khoản hoặc mật khẩu");
                }
                else if (!user.IsActive)
                {
                    result.Add("status", 400);
                    result.Add("message", "Tài khoản bị khóa");
                }
                else
                {
                    var claims = new[]
                       {
                       new Claim(JwtRegisteredClaimNames.Sub, "AuthorizeWithJWTToKen"),
                        new Claim(JwtRegisteredClaimNames.Email, "hrm@cbbank.vn"),
                        new Claim(JwtRegisteredClaimNames.Website, "api.hrm.cbbank.vn"),
                        new Claim("userinfo", JsonConvert.SerializeObject(user)),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    var jwt = GenerateJSONWebToken(claims);
                    result.Add("status", 200);
                    result.Add("token", jwt);
                    result.Add("user", user);
                }
            }
            catch(Exception ex)
            {
                result.Add("status", 400);
                result.Add("message", ex.Message);
            }

            
            return result;
        }

        private string GenerateJSONWebToken(IEnumerable<Claim> claims)
        {
            string result = string.Empty;
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials
                );
                result = new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }


        public Dictionary<string, object> Register(RegisterDTO registerDTO)
        {
            var result = new Dictionary<string, object>();
            try
            {
                var user = new Users()
                {
                    Id = Guid.NewGuid(),
                    Username = registerDTO.Username,
                    Password = Users.ChangeSha512(registerDTO.Password),
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };

                _resturantDb.Users.Add(user);
                var isSave = _resturantDb.SaveChanges();
                if (isSave == 1)
                {
                    result.Add("message", "Thành công");
                    result.Add("status", 200);
                }
                else
                {
                    result.Add("message", "Thất bại");
                    result.Add("status", 400);
                }
            }
            catch(Exception ex)
            {
                result.Add("message", ex.Message);
                result.Add("status", 400);
            }
            return result;
        }

        public List<dynamic> Gets()
        {
            return _resturantDb.Users.ToList<dynamic>();
        }
    }
}
