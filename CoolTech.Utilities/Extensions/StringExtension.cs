using Newtonsoft.Json;
using System.Text;

namespace CoolTech.Utilities
{
    public static class StringExtension
    {
        public static StringContent AsJson(this object o)
       => new StringContent(JsonConvert.SerializeObject(o), Encoding.UTF8, "application/json");
    }
}
