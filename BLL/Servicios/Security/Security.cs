using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;

namespace BLL.Servicios.Security
{
    public class Security : ISecurity
    {
        public Security() { }
        public SecurityDTO Encript(string password)
        {
            Guid userGuid = System.Guid.NewGuid();
            var passGUID = password + userGuid;
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(passGUID);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return new SecurityDTO
            {
                GUID = userGuid,
                hashPass = sb.ToString()
            };
        }
        public SecurityDTO Encript(string password, Guid guid)
        {
            var passGUID = password + guid;
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(passGUID);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return new SecurityDTO
            {
                GUID = guid,
                hashPass = sb.ToString()
            };
        }
    }
}
