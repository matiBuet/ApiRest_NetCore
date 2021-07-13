using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Model;
using Entities.DTO;
namespace BLL.IBLL
{
    public interface IAccountBLL
    {
        public void Create(AccountDTO account, string user);
        public void Delete(long id, string usuario);
        public void Update(long id, AccountDataDTO account,string usuario);
        public List<AccountDataDTO> GetAll();
        public Account GetByUsuario(string usuario);
    }
}
