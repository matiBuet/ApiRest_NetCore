using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Servicios.JWT
{
    public interface IJwtAuthentication
    {
        public string Authenticate(string username, string password);
    }
}
