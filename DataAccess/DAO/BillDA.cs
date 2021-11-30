using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDA
    {
        public List<Bill> GetAll()
        {
            using(SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Ultilities.Bill_GetAll;

                SqlDataReader reader = command.ExecuteReader();
                List<Bill> list = new List<Bill>();

                while (reader.Read())
                {
                    Bill bill = new Bill();
                    bill.ID = Convert.ToInt32(reader[0]);
                    bill.Name = Convert.ToString(reader[1]);
                    bill.TableID = Convert.ToInt32(reader[2]);
                    bill.Account = Convert.ToString(reader[3]);
                    bill.Discount = Convert.ToDouble(reader[4]);
                    bill.Tax = Convert.ToInt32(reader[5]);
                    bill.Status = Convert.ToByte(reader[6]);
                    bill.CheckoutDate = Convert.ToDateTime(reader[7].ToString()==""?DateTime.MinValue.ToString(): reader[7]);
                    bill.Account = Convert.ToString(reader[8]);
                    list.Add(bill);
                }
                sqlConn.Close();
                return list;
            }
        }

        public int Insert_Update_Delete(Bill bill, int action)
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();

            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Bill_GetAll;

            SqlParameter IDPara = new SqlParameter("@ID", SqlDbType.Int);
            IDPara.Direction = ParameterDirection.InputOutput; // Vừa vào vừa ra
            command.Parameters.Add(IDPara).Value = bill.ID;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = bill.Name;
            command.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
            command.Parameters.Add("@Amount", SqlDbType.Int).Value = bill.Amount;
            command.Parameters.Add("@Discount", SqlDbType.Float).Value = bill.Discount;
            command.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
            command.Parameters.Add("@TableID", SqlDbType.Int).Value = bill.TableID;
            command.Parameters.Add("@Action", SqlDbType.Int).Value = action;

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                return (int)command.Parameters["ID"].Value;
            }
            return 0;
        }
    }
}
