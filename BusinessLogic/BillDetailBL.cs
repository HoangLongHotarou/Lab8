using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BillDetailBL
    {
        BillDetailDA billDetailDA = new BillDetailDA();

        public List<BillDetail> GetAll()
        {
            return billDetailDA.GetAll();
        }

        public int Quantity(int _foodID)
        {
            return GetAll().FindAll(x => x.FoodID == _foodID).ToList().Sum(x=>x.Quantity);
        }

        public DataTable LoadDetailFromID(int id)
        {
            return billDetailDA.Load_Bill_Detail(id);
        }
    }
}
