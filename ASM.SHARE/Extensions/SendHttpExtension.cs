using ASM.SHARE.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Extensions
{
    public static class SendHttpExtension
    {
        public async static Task<DataJsonResult> ToDataJsonResultAsync(this HttpResponseMessage httpResponse)
        {
            var finalData = await httpResponse.Content.ReadAsStringAsync();
            var _dataResponse = JsonConvert.DeserializeObject<DataJsonResult>(finalData);
            return _dataResponse;
        }

        public static StringContent ToJsonBody(this object model)
        {
            var json = JsonConvert.SerializeObject(model);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
