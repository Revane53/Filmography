using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Filmographys.Class
{
    static public class Connection
    {
        static SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;initial Catalog=Filmography;Integrated Security=true;");
        static string connection_string = @"Data Source=.\SQLEXPRESS;initial Catalog=Filmography;Integrated Security=true;";
        static SqlDataAdapter adapter;
        public static DataTable GetTable(string com)
        {
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(com, connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataSet GetTables(string com)
        {
            adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(com, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public static int Test(string com, List<SqlParameter> param)
        {
            using (SqlConnection connection = new SqlConnection(connection_string))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(com, connection);
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;
                param.ForEach(r => command.Parameters.Add(r));

                var result = Convert.ToInt32(command.ExecuteScalar());
                return result;
            }
        }

        public static void InserToTable(DataTable dt, string com)
        {
            adapter.InsertCommand = new SqlCommand(com, connection);
            adapter.Update(dt);
        }
        public static void InserToTable(DataSet ds, string com)
        {
            adapter.InsertCommand = new SqlCommand(com, connection);
            adapter.Update(ds);
        }

        public static void Delete(DataTable dt, string com)
        {
            adapter.DeleteCommand = new SqlCommand(com, connection);
            adapter.Update(dt);
            //adapter.Update()
        }
        public static DataTable updatecom(DataTable dt, string com)
        {
            adapter.SelectCommand = new SqlCommand(com, connection);
            adapter.Fill(dt);
            return dt;
        }
    }
}
