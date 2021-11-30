using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class TableDA
    {
        public List<Table> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Table_GetAll;
            SqlDataReader reader = command.ExecuteReader();
            List<Table> list = new List<Table>();
            while (reader.Read())
            {
                Table table = new Table();
                table.ID = int.Parse(reader[0].ToString());
                table.Name = reader[1].ToString();
                table.status = int.Parse(reader[2].ToString());
                table.capacity = int.Parse(reader[3].ToString());
                list.Add(table);
            }
            return list;
        }
    }
}
