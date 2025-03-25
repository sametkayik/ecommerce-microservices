using System.Security.AccessControl;
using static Ecommerce.Web.SD;

namespace Ecommerce.Web.Models
{
    public class ApiRequest
    {
        public SD.ApiType ApiType { get; set; } = SD.ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
    }
}
