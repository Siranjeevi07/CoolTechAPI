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


        public async Task<List<NDistribution>> GetNDistribution(string operationCode, string docType, string docNo, string wmsStatus)
        {
            SalesRepo salesRepo = new SalesRepo();

            DataTable dt = await salesRepo.GetWmsDistribution(operationCode, docType, docNo, wmsStatus);

            List<NDistribution> target = dt.ToList<NDistribution>();
            return target;


        }

        public async Task<List<SODDistribution>> GetSODDistribution(string operationCode, string docType, string docNo, string wmsStatus)
        {
            SalesRepo salesRepo = new SalesRepo();
            DataTable dt = await salesRepo.GetWmsDistribution(operationCode, docType, docNo, wmsStatus);

            List<SODDistribution> target = dt.ToList<SODDistribution>();
            return target;

        }

        public async Task<List<VDistribution>> GetVDistribution(string operationCode, string docType, string docNo, string wmsStatus)
        {
            SalesRepo salesRepo = new SalesRepo();
            DataTable dt = await salesRepo.GetWmsDistribution(operationCode, docType, docNo, wmsStatus);

            List<VDistribution> target = dt.ToList<VDistribution>();
            return target;
        }

        public async Task<List<V1Distribution>> GetV1Distribution(string operationCode, string docType, string docNo, string wmsStatus)
        {
            SalesRepo salesRepo = new SalesRepo();
            DataTable dt = await salesRepo.GetWmsDistribution(operationCode, docType, docNo, wmsStatus);

            List<V1Distribution> target = dt.ToList<V1Distribution>();
            return target;
        }
    }
}
