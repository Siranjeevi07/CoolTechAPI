using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Sales
{
    public class SalesBL : ISalesBL
    {
        public SalesBL() { }

        public string CheckSalesStatus()
        {
            SalesRepo salesRepo = new SalesRepo();
           DataSet ds = salesRepo.CheckSalesStatus();
            return string.Empty;
        }
    }
}
