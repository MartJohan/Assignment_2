using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace dotnetcore.DAL
{
    public class DBHelper
    {

        public SqlConnectionStringBuilder Builder { get; set; }
        public SqlConnection Connection { get; set; }

        public DBHelper(string dataSource, string initialCatalog)
        {
            Builder = new SqlConnectionStringBuilder();
            Builder.DataSource = dataSource;
            Builder.InitialCatalog = initialCatalog;
            Builder.IntegratedSecurity = true;

            Console.WriteLine(Builder.ConnectionString);

        }

        public void InsertQuery(string table, string[] keys, string[] values)
        {
            string keysString = string.Join(",", keys);
            string atKeyString = "@" + string.Join(", @", keys);


            string sql = $"INSERT INTO {table} ({keysString}) VALUES ({atKeyString})";
            using (Connection = new SqlConnection(Builder.ConnectionString))
            {
                Connection.Open();

                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    for (int i = 0; i < keys.Length; i++)
                    {
                        command.Parameters.AddWithValue("@" +keys[i], values[i]);
                    }
                    
                    command.ExecuteNonQuery();
                }
            }




        }



    }
}
