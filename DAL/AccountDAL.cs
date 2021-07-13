using DAL.DBContext;
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
    }
}
