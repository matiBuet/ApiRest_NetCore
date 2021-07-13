using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using BLL.IBLL;
using BLL.BLL;
using BLL.Servicios.Security;

namespace BLL.Servicios.JWT
{
    public class JwtAuthentication : IJwtAuthentication
    {
        private readonly string _key;
        private readonly IAccountBLL _account;
        private readonly ISecurity _security;

        public JwtAuthentication(string key, IAccountBLL account)
        {
            _key = key;
            _account = account;
            _security = new Security.Security();
        }

        public string Authenticate(string username, string password)
        {
            var dbAccount = _account.GetByUsuario(username);
            if (string.IsNullOrEmpty(dbAccount.usuario))
                return null;
            else
            {
                if (dbAccount.pass == _security.Encript(password, dbAccount.guid).hashPass)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(_key);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.Name, username)
                        }),
                        Expires = DateTime.UtcNow.AddHours(2),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
                else
                    return null;
            }
        }
    }
}
