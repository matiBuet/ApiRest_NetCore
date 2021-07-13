using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTO;

namespace BLL.Servicios.Security
{
    public interface ISecurity
    {
        public SecurityDTO Encript(string password);
        public SecurityDTO Encript(string password, Guid guid);
    }
}
