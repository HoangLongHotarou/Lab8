using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillBL
    {
        BillDA billDA = new BillDA();
        public List<Bill> Bills { get; set; }

        public List<Bill> GetAll()
        {
            return this.Bills = billDA.GetAll();
        }

        public object[] Search(DateTime dateTime)
        {
            var search = Bills.FindAll(x => x.CheckoutDate.Date == dateTime.Date);
            int amount = search.Sum(x => x.Amount);
            return new object[] { search, amount };
        }
    }
}
