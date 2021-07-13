using System;
using System.Collections.Generic;
using System.Text;
using BLL.IBLL;
using Entities.DTO;

namespace BLL.BLL
{
    class AccountBLL : IAccountBLL
    {
        void IAccountBLL.Create(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        void IAccountBLL.Delete(long id)
        {
            throw new NotImplementedException();
        }

        void IAccountBLL.Login(string usuario, string pass)
        {
            throw new NotImplementedException();
        }

        void IAccountBLL.Select()
        {
            throw new NotImplementedException();
        }

        void IAccountBLL.Select(string usuario)
        {
            throw new NotImplementedException();
        }

        void IAccountBLL.Update(long id, AccountDTO account)
        {
            throw new NotImplementedException();
        }
    }
}
