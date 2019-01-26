using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class DataBaseController
    {
        private string connectionString;
        private SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        private SqlDataReader sqlDataReader = null;

        public string ConnectionString { get => connectionString; set => connectionString = value; }

        public DataBaseController(string connectionString)
        {
            this.connectionString = connectionString;

            if (connectionString != null)
            {
                sqlConnection = new SqlConnection(connectionString);
            }
            else
            {
                throw new Exception("Connection string not defined.");
            }
        }

        public List<Dictionary<string, dynamic>> ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            try
            {
                List<Dictionary<string, dynamic>> res = new List<Dictionary<string, dynamic>>();

                sqlConnection.Open();

                sqlCommand = new SqlCommand(query, sqlConnection);
                foreach (SqlParameter param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Dictionary<string, dynamic> row = new Dictionary<string, dynamic>();
                    for (int i = 0; i < sqlDataReader.FieldCount; i++)
                    {
                        row[sqlDataReader.GetName(i)] = Convert.IsDBNull(sqlDataReader[sqlDataReader.GetName(i)]) ? null : sqlDataReader[sqlDataReader.GetName(i)];
                    }
                    res.Add(row);
                }

                return res;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            try
            {
                sqlConnection.Open();

                sqlCommand = new SqlCommand(query + ";SELECT SCOPE_IDENTITY()", sqlConnection);
                foreach (SqlParameter param in parameters)
                {
                    sqlCommand.Parameters.Add(param);
                }

                var resultado = sqlCommand.ExecuteScalar();

                if (!resultado.Equals(DBNull.Value))
                {
                    int identity = Convert.ToInt32(resultado);
                    return identity;
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
