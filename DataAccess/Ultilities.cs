using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Ultilities
    {
        // Get string connects from app.config
        private static string StrName = "Conection";
        private static Ultilities instance;

        public static string ConnectionString = ConfigurationManager.ConnectionStrings[StrName].ConnectionString;

        // the variable of Food Table
        public static string Account_GetAll = "Account_GetAll";
        public static string Bill_GetAll = "Bill_GetAll";
        public static string BillDetail_GetAll = "BillDetail_GetAll";
        public static string Role_GetAll = "Role_GetAll";
        public static string RoleAccount_GetAll = "RoleAccount_GetAll";
        public static string Table_GetAll = "Table_GetAll";
        public static string Food_GetAll = "Food_GetAll";
        public static string Category_GetAll = "Category_GetAll";


        public static string Account_InsertUpdateDelete = "Account_InsertUpdateDelete";
        public static string Bill_InsertUpdateDelete = "Bill_InsertUpdateDelete";
        public static string BillDetail_InsertUpdateDelete = "BillDetail_InsertUpdateDelete";
        public static string Role_InsertUpdateDelete = "Role_InsertUpdateDelete";
        public static string RoleAccount_InsertUpdateDelete = "RoleAccount_InsertUpdateDelete";
        public static string Table_InsertUpdateDelete = "Table_InsertUpdateDelete";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";


        public static Ultilities Instance
        {
            get { if (instance == null) return instance = new Ultilities();return instance; }
            private set { instance = value; }
        }

        public DataTable ExecuteQuery(string query,object[] parameter = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand))
                {
                    adapter.Fill(table);
                }
            }
            return table;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = sqlCommand.ExecuteNonQuery();
            }
            return data;
        }

        public object ExcuteScalarQuery(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string para in listPara)
                    {
                        if (para.Contains('@'))
                        {
                            sqlCommand.Parameters.AddWithValue(para, parameter[i]);
                            i++;
                        }
                    }
                }
                data = sqlCommand.ExecuteScalar();
            }
            return data;
        }
    }
}
