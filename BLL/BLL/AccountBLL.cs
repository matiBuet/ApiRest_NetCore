using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.IBLL;
using Entities.DTO;
using Entities.Model;
using Entities.Mapping;
using BLL.Servicios.Security;
using DAL;

namespace BLL.BLL
{
    public class AccountBLL : IAccountBLL
    {
        private readonly IMapper _mapper;
        private readonly ISecurity _security;
        public AccountBLL(IMapper mapper, ISecurity security)
        {
            _mapper = mapper;
            _security = security;
        }
        void IAccountBLL.Create(AccountDTO account, string user)
        {
            var entity = _mapper.Map<Account>(account);
            var securityData = _security.Encript(account.pass);
            entity.eliminado = false;
            entity.fechaAlta = DateTime.Now;
            entity.usuarioAlta = user;
            entity.guid = securityData.GUID;
            entity.pass = securityData.hashPass;
            new AccountDAL().Create(entity);
        }

        void IAccountBLL.Delete(long id, string usuario)
        {
            AccountDAL accountDAL = new AccountDAL();
            var orgEntity = accountDAL.GetById(id);
            if (orgEntity != null)
            {

                orgEntity.usuarioModificacion = usuario;
                orgEntity.fechaModificacion = DateTime.Now;
                orgEntity.eliminado = true;
                accountDAL.Update(id, orgEntity);
            }
        }

        List<AccountDataDTO> IAccountBLL.GetAll()
        {
            return _mapper.Map<List<AccountDataDTO>>(new AccountDAL().GetAll());
        }

        Account IAccountBLL.GetByUsuario(string usuario)
        {
            AccountDTO accountDTO = new AccountDTO();
            var usuarioAcc = new AccountDAL().GetByUsuario(usuario);
            return usuarioAcc;
        }

        void IAccountBLL.Update(long id, AccountDataDTO accountDTO, string usuario)
        {
            AccountDAL accountDAL = new AccountDAL();
            bool modifico = false;
            var orgEntity = accountDAL.GetById(id);
            if (orgEntity != null)
            {
                if (string.IsNullOrEmpty(accountDTO.nombre))
                {
                    orgEntity.nombre = accountDTO.nombre;
                    modifico = true;
                }
                if (string.IsNullOrEmpty(accountDTO.apellido))
                {
                    orgEntity.apellido = accountDTO.apellido;
                    modifico = true;
                }
                if (string.IsNullOrEmpty(accountDTO.mail))
                {
                    orgEntity.mail = accountDTO.mail;
                    modifico = true;
                }
                if (string.IsNullOrEmpty(accountDTO.usuario))
                {
                    orgEntity.usuario = accountDTO.usuario;
                    modifico = true;
                }

                if (modifico)
                {
                    orgEntity.usuarioModificacion = usuario;
                    orgEntity.fechaModificacion = DateTime.Now;
                    accountDAL.Update(id, orgEntity);
                }
            }
        }
    }
}
