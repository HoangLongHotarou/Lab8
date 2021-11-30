using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class TableBL
    {
        TableDA _tableDA= new TableDA();

        public List<Table> Tables = new List<Table>();
        
        public List<Table> GetAll()
        {
            return Tables = _tableDA.GetAll();
        }
    }
}
