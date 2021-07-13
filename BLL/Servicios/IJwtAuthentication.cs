using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Servicios
{
    public interface IJwtAuthentication
    {
        public string Authenticate(string username, string password);
    }
}
