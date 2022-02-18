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

        private IAuth _auth;

        public CtrlLogin(IAuth auth)
        {
            _auth = auth;
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
                    oR.data = _auth.GetNewToken(login);
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
    }   
}
