using CoolTech.Utilities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataAccessLayer.Repository
{
    public class SalesRepo
    {
        /// <summary>
        /// Sales repo to check the sales order status
        /// </summary>
        public SalesRepo() { }

        /// <summary>
        /// To check the Sales Order status for the operationCode
        /// </summary>
        /// <param name="operationCode"></param>
        /// <returns></returns>
        public async Task<DataTable> CheckSalesOrderStatus(string operationCode)
        {
            DBHelper dBHelper = new DBHelper();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add("@op".CreateSQLParameter(operationCode, ParameterDirection.Input));
            return dBHelper.ExecDT(CommandType.StoredProcedure, "[dbo].[SP_APP_WMS_SO_STATUS_DISPLAY]", sqlParameters);
        }
    }
}
