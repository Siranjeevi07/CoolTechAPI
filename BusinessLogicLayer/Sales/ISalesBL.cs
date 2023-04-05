using CoolTech.Utilities.Models;
using System.Data;

namespace BusinessLogicLayer.Sales
{
    public interface ISalesBL
    {
       Task<List<CheckSalesOrderStatModel>> CheckSalesOrderStatus(string operation);
    }
}
