using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class RoleAccount
    {
        public int RoleID { get; set; }
        public string AccountName { get; set; }
        public byte Actived { get; set; }
        public string Notes { get; set; }
    }
}
