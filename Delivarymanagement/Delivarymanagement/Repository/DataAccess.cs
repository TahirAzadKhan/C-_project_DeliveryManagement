using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivarymanagement.Repository
{
    public class DataAccess:IDisposable
    {
        private SqlConnection connection;
        private SqlCommand command;
        public DataAccess()
        {
            this.connection = new SqlConnection(@"data source=DESKTOP-KDDNL1K;initial catalog=Spring 2019-20;integrated security=true;");
           
            this.connection.Open();
        }

        public SqlDataReader GetData(string sql)
        {
            this.command = new SqlCommand(sql,this.connection);
            return this.command.ExecuteReader();
        }

        public int ExecuteQuery(string sql)
        {
            this.command = new SqlCommand(sql,this.connection);
            return this.command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            this.connection.Close();
        }
    }
}
