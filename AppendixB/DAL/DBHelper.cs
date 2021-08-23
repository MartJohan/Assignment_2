using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace dotnetcore.DAL
{
    public class DBHelper
    {

        SqlConnectionStringBuilder builder;
        SqlConnection connection;

        public DBHelper(string dataSource, string initialCatalog)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = dataSource;
            builder.InitialCatalog = initialCatalog;
            builder.IntegratedSecurity = true;

            using (connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
            }
        }



    }
}
