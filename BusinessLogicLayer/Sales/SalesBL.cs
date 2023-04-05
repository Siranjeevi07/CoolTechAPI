using CoolTech.Utilities;
using CoolTech.Utilities.Models;
using DataAccessLayer.Repository;
using System.Data;

namespace BusinessLogicLayer.Sales
{
    public class SalesBL : ISalesBL
    {
        public SalesBL() { }

        public async Task<List<CheckSalesOrderStatModel>> CheckSalesOrderStatus(string operationCode)
        {
            SalesRepo salesRepo = new SalesRepo();
            DataTable dt = await salesRepo.CheckSalesOrderStatus(operationCode);

            List<CheckSalesOrderStatModel> target = dt.ToList<CheckSalesOrderStatModel>();
            return target;
        }
    }
}
