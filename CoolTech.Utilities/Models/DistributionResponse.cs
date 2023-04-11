using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolTech.Utilities.Models
{
    public class NDistribution
    {
        public string Doc_No { get; set; }
        public DateTime Created_Date { get; set; }
        public string Notes { get; set; }
        public int Item_Count { get; set; }
   
    }

    public class SODDistribution
    {
        public string Doc_No { get; set; }
        public DateTime Created_Date { get; set; }
        public string Notes { get; set; }
        public string Item_code { get; set; }
        public string Item_Desc_Eng { get; set; }
        public string Item_Desc_Arb { get; set; }
        public int Quantity { get; set; }
        public string Picked_Qty { get; set; }
        public string Zone { get; set; }
        public int Item_Count_By_Zone { get; set; }

    }

    public class VDistribution
    {
        public string Doc_No { get; set; }
        public DateTime Created_Date { get; set; }
        public string Notes { get; set; }
        public int Item_Count { get; set; }

    }

    public class V1Distribution
    {
        public string Doc_No { get; set; }
        public DateTime Created_Date { get; set; }
        public string Notes { get; set; }
        public string Item_code { get; set; }
        public string Item_Desc_Eng { get; set; }
        public string Item_Desc_Arb { get; set; }
        public int Quantity { get; set; }
        public string Picked_Qty { get; set; }
        public string Zone { get; set; }
        public int Item_Count_By_Zone { get; set; }
        public List<MessageDistribution> MessageDistributions { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Storage> Storages { get; set; }
        public List<Package> Packages { get; set; }

    }

    public class MessageDistribution {
       public string Message { get; set; }
    }

    public class Cart
    {
        public string Cart_No { get; set; }
    }

    public class Storage
    {
        public string Storage_No { get; set; }
    }
    public class Package
    {
        public string  Packing_Instruction { get; set; }
        public string  Packing_Name { get; set; }
    }



}
