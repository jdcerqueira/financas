using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financas_core
{
    public class DAO
    {

        private const String strConnection = @"Server=DESKTOP-SCVFDSG\SQL2019A;Database=FINANCAS;User Id=lgn_financas;Password=lgn_financas;";
        private static SqlConnection connection = new SqlConnection(strConnection);

        public static SqlDataReader resultSet(String stmt)
        {
            SqlCommand sqlCommand = new SqlCommand(stmt, connection);
            if (sqlCommand.Connection.State == System.Data.ConnectionState.Open)
                sqlCommand.Connection.Close();

            sqlCommand.Connection.Open();
            return sqlCommand.ExecuteReader();
        }
    }
}
