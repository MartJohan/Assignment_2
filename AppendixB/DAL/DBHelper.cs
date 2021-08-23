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

        public void Connect()
        {

            string sql = "INSERT INTO Genre(Name) VALUES (@Name)";
            using (Connection = new SqlConnection(Builder.ConnectionString))
            {
                Connection.Open();
                Console.WriteLine("State: {0}", Connection.State);

                using (SqlCommand command = new SqlCommand(sql, Connection))
                {
                    command.Parameters.AddWithValue("@Name", "Tien");
                    Console.WriteLine("asfasf");
                    command.ExecuteNonQuery();
                }
            }




        }



    }
}
