using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeLogController : ControllerBase
    {
        private static string? _token;
        private static string _timeLogUrl = "";
        private static string? _refreshToken;
        private static DateTime _tokenCreationTime;

        // Development enviroment (clientId and client secret doesn't work anymore. Use production clientId and secret with locahost redirect uri)
        //private static string _clientId = "sampleapp";
        //private static string _client_secret = "timelog4life";
        //private static string _redirectUriDev = "https://localhost:7123";

        // Production enviroment
        private static string _clientId = "";
        private static string _client_secret = "";
        private static string _redirectUriProd = "";



        [HttpGet("GetProjectTemplates")]
        public async Task<ProjectTemplates> GetProjectTemplates()
        {

            if (_token != null && _timeLogUrl != null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {

                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(_timeLogUrl + "/api/v1/project-template/get-all"),
                        };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var response = await client.SendAsync(request);

                        var responseBody = await response.Content.ReadAsStringAsync();
                        var jObject = JObject.Parse(responseBody);
                        ProjectTemplates projectTemplates = jObject.ToObject<ProjectTemplates>();
                        return projectTemplates;
                    }
                }
            }
            return null;
        }

        [HttpGet("GetProjects")]
        public async Task<Projects> GetProjects(long customerID)
        {
            if (_token != null && _timeLogUrl != null)
            {
                TimeSpan duration = DateTime.Now.Subtract(_tokenCreationTime);

                if (duration.Hours >= 1)
                {
                    await RefreshToken();
                }
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        int pagesize = 150;
                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(_timeLogUrl + $"/api/v1/project/get-all?$pagesize={pagesize}&customerID={customerID}"),
                        };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var response = await client.SendAsync(request);

                        var responseBody = await response.Content.ReadAsStringAsync();
                        dynamic jObject = JObject.Parse(responseBody);
                        Projects projects = jObject.ToObject<Projects>();

                        return projects;
                    }
                }
            }
            return null;
        }

        [HttpGet("GetUsers")]
        public async Task<TimeLogUser> GetUsers()
        {
            if (_token != null && _timeLogUrl != null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        int pagesize = 150;
                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(_timeLogUrl + $"/api/v1/user?$pagesize={pagesize}"),
                        };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        dynamic jObject = JObject.Parse(responseBody);

                        TimeLogUser users = jObject.ToObject<TimeLogUser>();
                        int totalRecords = jObject["Properties"]["TotalRecord"];

                        if (totalRecords > pagesize)
                        {
                            var request2 = new HttpRequestMessage
                            {
                                Method = HttpMethod.Get,
                                RequestUri = new Uri(_timeLogUrl + $"/api/v1/user?$pagesize={totalRecords}"),
                            };
                            var response2 = await client.SendAsync(request2);
                            response2.EnsureSuccessStatusCode();
                            var responseBody2 = await response2.Content.ReadAsStringAsync();
                            dynamic jObject2 = JObject.Parse(responseBody2);
                            users = jObject2.ToObject<TimeLogUser>();
                        }

                        return users;
                    }
                }
            }
            return null;
        }

        [HttpGet("GetCustomers")]
        public async Task<TimeLogCustomer> GetCustomers()
        {
            if (_token != null && _timeLogUrl != null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        int pagesize = 150;
                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(_timeLogUrl + $"/api/v1/customer?$pagesize={pagesize}"),
                        };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        dynamic jObject = JObject.Parse(responseBody);

                        TimeLogCustomer customers = jObject.ToObject<TimeLogCustomer>();
                        int totalRecords = jObject["Properties"]["TotalRecord"];

                        if (totalRecords > pagesize)
                        {
                            var request2 = new HttpRequestMessage
                            {
                                Method = HttpMethod.Get,
                                RequestUri = new Uri(_timeLogUrl + $"/api/v1/customer?$pagesize={totalRecords}"),
                            };
                            var response2 = await client.SendAsync(request2);
                            response2.EnsureSuccessStatusCode();
                            var responseBody2 = await response2.Content.ReadAsStringAsync();
                            dynamic jObject2 = JObject.Parse(responseBody2);
                            customers = jObject2.ToObject<TimeLogCustomer>();
                        }


                        return customers;
                    }
                }
            }
            return null;
        }

        [HttpGet("GetProjectTypes")]
        public async Task<ProjectTypes> GetProjectTypes()
        {
            if (_token != null && _timeLogUrl != null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(_timeLogUrl + $"/api/v1/ProjectType?$pagesize=150"),
                        };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        dynamic jObject = JObject.Parse(responseBody);

                        ProjectTypes projectTypes = jObject.ToObject<ProjectTypes>();


                        return projectTypes;
                    }
                }
            }
            return null;
        }

        [HttpGet("GetProjectCategories")]
        public async Task<ProjectCategories> GetProjectCategories()
        {
            if (_token != null && _timeLogUrl != null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        int pagesize = 150;
                        var request = new HttpRequestMessage
                        {
                            Method = HttpMethod.Get,
                            RequestUri = new Uri(_timeLogUrl + $"/api/v1/ProjectCategory?$pagesize={pagesize}"),
                        };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var response = await client.SendAsync(request);
                        response.EnsureSuccessStatusCode();
                        var responseBody = await response.Content.ReadAsStringAsync();
                        dynamic jObject = JObject.Parse(responseBody);

                        ProjectCategories categories = jObject.ToObject<ProjectCategories>();

                        int totalRecords = jObject["Properties"]["TotalRecord"];

                        if (totalRecords > pagesize)
                        {
                            var request2 = new HttpRequestMessage
                            {
                                Method = HttpMethod.Get,
                                RequestUri = new Uri(_timeLogUrl + $"/api/v1/user?$pagesize={totalRecords}"),
                            };
                            var response2 = await client.SendAsync(request2);
                            response2.EnsureSuccessStatusCode();
                            var responseBody2 = await response2.Content.ReadAsStringAsync();
                            dynamic jObject2 = JObject.Parse(responseBody2);
                            categories = jObject2.ToObject<ProjectCategories>();
                        }

                        return categories;
                    }
                }
            }
            return null;
        }

        [HttpGet("GetTimeLogToken")]
        public async Task<string> GetTimeLogToken(string grant)
        {
            //Get token
            var url = "https://login.timelog.com/connect/token";

            try
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        //Step 4 Get Token
                        var nvc = new List<KeyValuePair<string, string>>();
                        nvc.Add(new KeyValuePair<string, string>("client_id", _clientId));
                        nvc.Add(new KeyValuePair<string, string>("client_secret", _client_secret));
                        nvc.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                        nvc.Add(new KeyValuePair<string, string>("code", grant));
                        // If development enviroment use development redirect uri. Otherwise use production redirect uri.
                        //nvc.Add(new KeyValuePair<string, string>("redirect_uri", _redirectUriDev));
                        nvc.Add(new KeyValuePair<string, string>("redirect_uri", _redirectUriProd));

                        var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(nvc) };

                        var res = await client.SendAsync(req);
                        string res1 = await res.Content.ReadAsStringAsync();

                        res.EnsureSuccessStatusCode();

                        string json;
                        json = JsonConvert.SerializeObject(new
                        {
                            status = res.StatusCode
                        });

                        if (res.IsSuccessStatusCode)
                        {
                            string content = await res.Content.ReadAsStringAsync();
                            JObject obj = JObject.Parse(content);
                            _token = (string?)obj["access_token"];
                            _refreshToken = (string?)obj["refresh_token"];
                            _tokenCreationTime = DateTime.Now;

                            json = JsonConvert.SerializeObject(new
                            {
                                status = res.StatusCode,
                                data = content
                            });
                        }

                        return json;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ex.ToString();
            }
        }
        [HttpGet("RefreshToken")]
        public async System.Threading.Tasks.Task RefreshToken()
        {
            var url = "https://login.timelog.com/connect/token";

            if (_refreshToken is not null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {
                        //Step 4 Get Token
                        var nvc = new List<KeyValuePair<string, string>>();
                        nvc.Add(new KeyValuePair<string, string>("client_id", _clientId));
                        nvc.Add(new KeyValuePair<string, string>("client_secret", _client_secret));
                        nvc.Add(new KeyValuePair<string, string>("grant_type", "refresh_token"));
                        nvc.Add(new KeyValuePair<string, string>("refresh_token", _refreshToken));
                        // If development enviroment use development redirect uri. Otherwise use production redirect uri.
                        //nvc.Add(new KeyValuePair<string, string>("redirect_uri", _redirectUriDev));
                        nvc.Add(new KeyValuePair<string, string>("redirect_uri", _redirectUriProd));

                        var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(nvc) };
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
                        var res = await client.SendAsync(req);
                        string content = await res.Content.ReadAsStringAsync();
                        JObject obj = JObject.Parse(content);

                        _token = (string?)obj["access_token"];

                        _tokenCreationTime = DateTime.Now;
                    }
                }
            }
        }

        [HttpPost("PostProject")]
        public async Task<string> PostProject([FromBody] string json)
        {
            TimeSpan duration = DateTime.Now.Subtract(_tokenCreationTime);

            if (duration.Hours >= 1)
            {
                await RefreshToken();
            }

            if (_token != null && _timeLogUrl != null)
            {
                using (var handler = new HttpClientHandler())
                {
                    using (var client = new HttpClient(handler))
                    {

                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                        var data = new StringContent(json, Encoding.UTF8, "application/json");

                        var url = _timeLogUrl + "/api/v1/project/create-from-template";

                        var response = await client.PostAsync(url, data);
                        var responseBody = await response.Content.ReadAsStringAsync();


                        return responseBody;
                    }
                }
            }
            return null;
        }

    }
}