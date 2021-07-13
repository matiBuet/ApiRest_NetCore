using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.IBLL;
using Entities.DTO;
using Entities.Model;
using Entities.Mapping;
using DAL;

namespace BLL.BLL
{
    public class AccountBLL : IAccountBLL
    {
        private readonly IMapper _mapper;
        public AccountBLL(IMapper mapper)
        {
            _mapper = mapper;
        }
        void IAccountBLL.Create(AccountDTO account)
        {
            var convert = _mapper.Map<Account>(account);
            convert.eliminado = false;
            convert.fechaAlta = DateTime.Now;
            convert.usuarioAlta = account.

           
            new AccountDAL().Create(convert);
        }

        void IAccountBLL.Delete(long id)
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
