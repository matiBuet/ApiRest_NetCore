using AutoMapper;
using DAL.DBContext;
using Entities.DTO;
using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        public void Create(Account account)
        {
            using (DataContext db = new DataContext())
            {
                db.Accounts.Add(account);
                db.SaveChanges();
            }
        }
        public Account GetByUsuario(string usuario)
        {
            using (DataContext db = new DataContext())
            {
                return db.Accounts.Where(n => n.eliminado == false && n.usuario == usuario).FirstOrDefault();
            }
        }
        public List<Account> GetAll()
        {
            using (DataContext db = new DataContext())
            {
                return db.Accounts.Where(n => n.eliminado == false).ToList();
            }
        }
        public Account GetById(long id)
        {
            using (DataContext db = new DataContext())
            {
                var dbAccount = db.Accounts.Where(n => n.eliminado == false && n.id == id).FirstOrDefault();
                return dbAccount;
            }
        }
        public Account Update(long id, Account account)
        {
            using (DataContext db = new DataContext())
            {
                db.Update(account);
                db.SaveChanges();
                return account;
            }
        }
    }
}
