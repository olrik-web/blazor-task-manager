using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreshdeskController : ControllerBase
    {
        // ************* FRESHDESK ******************
        [HttpGet("FreshdeskCompanies")]
        public async Task<string> GetAllCompanies()
        {
            var url = "";
            var response = await Send(url, "", HttpMethod.Get, "application/json");
            var json = await response.Content.ReadAsStringAsync();

            return json;
        }
        [HttpGet("FreshdeskTicket")]
        public async Task<FreshdeskCase> GetTicket(int ticketId)
        {
            var url = $"";
            var response = await Send(url, "", HttpMethod.Get, "application/json");
            if (response != null && response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var jObject = JObject.Parse(json);
                FreshdeskCase? freshdeskCase = new FreshdeskCase();
                if (jObject is not null)
                {
                    freshdeskCase = jObject.ToObject<FreshdeskCase>();
                }
                if (freshdeskCase != null)
                {
                    return freshdeskCase;

                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        [HttpGet("FreshdeskCompany")]
        public async Task<FreshdeskCompany> GetCompany(long companyId)
        {
            var url = $"";
            var response = await Send(url, "", HttpMethod.Get, "application/json");

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);

            FreshdeskCompany? freshdeskCompany = jObject.ToObject<FreshdeskCompany>();

            return freshdeskCompany;
        }
        [HttpGet("FreshdeskContact")]
        public async Task<FreshdeskContact> GetContact(long contactId)
        {
            var url = $"";
            var response = await Send(url, "", HttpMethod.Get, "application/json");

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);

            FreshdeskContact? freshdeskContact = jObject.ToObject<FreshdeskContact>();

            return freshdeskContact;
        }
        [HttpGet("FreshdeskAgent")]
        public async Task<FreshdeskAgent> GetAgent(long agentId)
        {
            var url = $"";
            var response = await Send(url, "", HttpMethod.Get, "application/json");

            var json = await response.Content.ReadAsStringAsync();
            var jObject = JObject.Parse(json);

            FreshdeskAgent? freshdeskAgent = jObject.ToObject<FreshdeskAgent>();

            return freshdeskAgent;
        }

        [HttpGet("FreshdeskContacts")]
        public async Task<List<FreshdeskContact>> GetContacts(long id)
        {
            var url = $"";
            var response = await Send(url, "", HttpMethod.Get, "application/json");

            var json = await response.Content.ReadAsStringAsync();
            JArray jsonArray = JArray.Parse(json);
            List<FreshdeskContact>? list = jsonArray.ToObject<List<FreshdeskContact>>();

            return list;
        }

        [HttpPut("FreshdeskUpdate")]
        public async Task<string> UpdateTicket(int ticketId, [FromBody] FreshdeskCase ticket)
        {
            var url = $"";

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                custom_fields = new
                {
                    cf_devops = ticket.custom_fields.cf_devops.ToString()
                }
            });

            var response = await Send(url, content, HttpMethod.Put, "application/json");

            var jsonResponse = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();

            return jsonResponse;
        }


        [HttpGet("FreshdeskSend")]
        public async Task<HttpResponseMessage> Send(string url, string body, HttpMethod httpMethod, string mediaType)
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    //handler.UseDefaultCredentials = true;
                    using (var client = new HttpClient(handler))
                    {
                        var httpRequestMessage = new HttpRequestMessage();
                        httpRequestMessage.Method = httpMethod;
                        httpRequestMessage.RequestUri = new Uri(url);

                        if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
                        {
                            //POST or PUT
                            httpRequestMessage.Content = new StringContent(body, Encoding.UTF8, mediaType);
                        }

                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(personalaccesstoken + ":X"));
                        httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                        var result = await client.SendAsync(httpRequestMessage);
                        result.EnsureSuccessStatusCode();

                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }



    }
}
