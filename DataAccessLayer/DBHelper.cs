using CoolTech.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DBHelper
    {
        public string _connString { get; set; }

        public DBHelper()
        {
            _connString = CommonConfig.connString;
        }

        public DataSet ExecDS(CommandType commandType, string commandText, List<SqlParameter> parameters)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = _connString;
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = commandType;
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters.ToArray());
                }
                command.CommandText = commandText;
                command.Connection = connection;
                command.CommandTimeout = 120;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds);

            }
            catch (Exception ex) { }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }

            }

            ds.AcceptChanges();
            foreach (DataTable dt in ds.Tables)
            {
                dt.AcceptChanges();
            }
            return ds;
        }

        public DataTable ExecDT(CommandType commandType, string commandText, List<SqlParameter> parameters)
        {
            DataSet dataSet = new DataSet();
            dataSet = ExecDS(commandType, commandText, parameters);

            if (dataSet != null && dataSet.Tables.Count > 0)
            {
                return dataSet.Tables[0];
            }
            return new DataTable();
        }
    }
}
