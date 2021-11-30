using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AccountBL
    {
        AccountDA account = new AccountDA();
        public List<Account> Accounts { get; set; }

        public List<Account> GetAll()
        {
            this.Accounts = account.GetAll();
            return this.Accounts;
        }
    }
}
