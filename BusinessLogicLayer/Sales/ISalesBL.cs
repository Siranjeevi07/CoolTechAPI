using CoolTech.Utilities.Models;
using System.Data;

namespace BusinessLogicLayer.Sales
{
    public interface ISalesBL
    {
        Task<List<CheckSalesOrderStatModel>> CheckSalesOrderStatus(string operation);

        Task<List<NDistribution>> GetNDistribution(string operationCode, string docType, string docNo, string wmsStatus);
        Task<List<SODDistribution>> GetSODDistribution(string operationCode, string docType, string docNo, string wmsStatus);
        Task<List<VDistribution>> GetVDistribution(string operationCode, string docType, string docNo, string wmsStatus);
        Task<List<V1Distribution>> GetV1Distribution(string operationCode, string docType, string docNo, string wmsStatus);
    }
}
