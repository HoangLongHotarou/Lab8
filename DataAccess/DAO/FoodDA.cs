using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FoodDA
    {
        public List<Food> GetAll()
        {
            SqlConnection sqlConn = new SqlConnection(Ultilities.ConnectionString);
            sqlConn.Open();
            SqlCommand command = sqlConn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = Ultilities.Food_GetAll;
            SqlDataReader reader = command.ExecuteReader();
            List<Food> list = new List<Food>();
            while (reader.Read())
            {
                Food food = new Food();
                food.ID = Convert.ToInt32(reader[0]);
                food.Name = reader[1].ToString();
                food.Unit = reader[2].ToString();
                food.FoodcategoryID = Convert.ToInt32(reader[3]);
                food.Price = Convert.ToInt32(reader[4]);
                food.Notes = reader[5].ToString();
                list.Add(food);
            }
            return list;
        }

        public DataTable LoadFood(int categoryID)
        {
            string query = $"SELECT * FROM Food Where FoodCategoryID = {categoryID}";
            return Ultilities.Instance.ExecuteQuery(query);
        }

        public int Insert_Update_Delete(Food food, int action)
        {
            string query = "EXEC Food_InsertUpdateDelete @ID , @Name , @Unit , @FoodCategoryID , @Price , @Notes , @action ";
            return Ultilities.Instance.ExcuteNonQuery(query,new object[] { food.ID,food.Name,food.Unit,food.FoodcategoryID,food.Price,food.Notes,action});
        }
    }
}
