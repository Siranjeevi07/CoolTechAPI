using System.Runtime.Serialization;

namespace CoolTech.Utilities
{

    public class APIResponseModel
    {
        public int? IsSuccess { get; set; } = 0;
        public string ResponseData { get; set; } = string.Empty;
        public int StatusCode { get; set; } 

       

    }
}
