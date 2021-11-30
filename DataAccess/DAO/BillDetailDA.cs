using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BillDetailDA
    {
        public List<BillDetail> GetAll()
        {
            using (SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString))
            {
                sqlConn.Open();
                SqlCommand command = sqlConn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Ultilities.BillDetail_GetAll;

                SqlDataReader reader = command.ExecuteReader();
                List<BillDetail> list = new List<BillDetail>();

                while (reader.Read())
                {
                    BillDetail billDetail = new BillDetail();
                    billDetail.ID = Convert.ToInt32(reader["ID"]);
                    billDetail.BillID = Convert.ToInt32(reader["InvoiceID"]);
                    billDetail.FoodID = Convert.ToInt32(reader["FoodID"]);
                    billDetail.Quantity = Convert.ToInt32(reader["Quantity"]);
                    list.Add(billDetail);
                }
                sqlConn.Close();
                return list;
            }
        }

        public DataTable Load_Bill_Detail(int id)
        {
            string query = $"SELECT B.ID,B.[InvoiceID],C.[NAME],B.[Quantity],B.[Quantity]*C.[Price] as Total FROM [BillDetails] as B,[FOOD] as C WHERE [InvoiceID] = {id} AND [FoodID] = C.ID";
            return Ultilities.Instance.ExecuteQuery(query);
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
