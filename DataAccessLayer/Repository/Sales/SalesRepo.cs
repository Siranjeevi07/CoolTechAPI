using System.Data;

namespace DataAccessLayer.Repository
{
    public class SalesRepo
    {

        public SalesRepo() { }

        public DataSet CheckSalesStatus()
        { 
           DBHelper dBHelper = new DBHelper();
          return  dBHelper.ExecDS(CommandType.StoredProcedure, "[dbo].[SP_APP_WMS_SO_STATUS_DISPLAY]", null);
        }
    }
}
