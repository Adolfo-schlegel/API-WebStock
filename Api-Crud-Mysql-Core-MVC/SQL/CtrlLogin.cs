using MySql.Data.MySqlClient;
using Api_Crud_Mysql_Core_MVC.Models.Common;
using Api_Crud_Mysql_Core_MVC.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Api_Crud_Mysql_Core_MVC.SQL.Interfaces;

namespace Api_Crud_Mysql_Core_MVC.SQL
{  
    public class CtrlLogin : ConnectionMysql.ConnectionToStocksWeb, ILogin
    {
        MySqlCommand? mySqlCommand;
        string? query;
        MySqlConnection mySqlConnection = connect();
        MySqlDataReader? reader;

        private readonly AppSettings? _appSettings;//sirve para obtener el secreto, para obtener el token 

        public CtrlLogin(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Reply Validate_User(Models.Login login)
        {           
            Reply oR = new Reply();
            try
            {
                
                query = "SELECT id_user FROM users WHERE Email = '" + login.Email + "' and Password = '" + login.Password +"' and idEstatus = '"+ 1 +"' ;";

                mySqlCommand = new MySqlCommand(query, mySqlConnection);

                reader = mySqlCommand.ExecuteReader();           
               
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        login.Id = reader.GetInt32(0); 
                    }

                    oR.result = 1;
                    oR.data = GetToken(login);
                    oR.message = "OK";
                }
                else
                {
                     oR.message = "Datos incorrectos";
                }                                       
            }
            catch (Exception)
            {
                oR.message = "Ocurrio un error, estamos trabajando en ello :)";
            }

            return oR;
        }

        private  string GetToken(Login model)
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
