using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api_Crud_Mysql_Core_MVC.Models;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;
using Api_Crud_Mysql_Core_MVC.Models.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Api_Crud_Mysql_Core_MVC.SQL
{
    public class Auth : IAuth
    {
        private readonly AppSettings? _appSettings;
        public Auth(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public string GetNewToken(Login model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_appSettings.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                        new Claim(ClaimTypes.NameIdentifier, model.Email.ToString()),
                    }
                ),

                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
