using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.WebApi.Patch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevOpsController : ControllerBase
    {

        // Getting DevOps team members which we can use it the "assigned to" field when creating a work item.
        [HttpGet("GetDevOpsTeamMembers")]
        public async Task<DevOpsTeamMembers> GetDevOpsTeamMembers()
        {
            string url = "";
            var responseBody = await GetDevOps(url);
            var jObject = JObject.Parse(responseBody);
            DevOpsTeamMembers? teamMembers = jObject.ToObject<DevOpsTeamMembers>();
            return teamMembers;
        }

        // Getting DevOps iterations which consists of sprints we display in a dropdown
        [HttpGet("DevOpsA2UIterations")]
        public async Task<DevOpsA2UWorkItemIteration> GetDevOpsA2UIterations()
        {
            string url = "";
            var responseBody = await GetDevOps(url);
            var jObject = JObject.Parse(responseBody);
            DevOpsA2UWorkItemIteration? devOpsA2UWorkItemIteration = jObject.ToObject<DevOpsA2UWorkItemIteration>();
            return devOpsA2UWorkItemIteration;
        }

        // Getting DevOps iterations which consists of sprints we display in a dropdown
        [HttpGet("DevOpsWMSIterations")]
        public async Task<DevOpsA2UWorkItemIteration> GetDevOpsWMSIterations()
        {
            string url = "";
            var responseBody = await GetDevOps(url);
            var jObject = JObject.Parse(responseBody);
            DevOpsA2UWorkItemIteration? devOpsA2UWorkItemIteration = jObject.ToObject<DevOpsA2UWorkItemIteration>();
            return devOpsA2UWorkItemIteration;
        }

        // GetDevOps is a helper function which gets and returns content from the parameter url
        [HttpGet("DevOpsGetDevOps")]
        public async Task<string> GetDevOps(string url)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", _personalaccesstoken))));

                    using (HttpResponseMessage response = await client.GetAsync(
                                url))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();

                        return responseBody;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /* 
         * This function sends a PATCH request to the DevOps REST API to create a work item. 
         * The data is sent in the json parameter from the client and parsed to a JsonPatchDocument. 
         * The function is used for work items of the type: Bug.
         */
        [HttpPost("DevOpsPostWMSBug")]
        public async Task<string> PostDevOpsWMSBug([FromBody] string json)
        {
            JsonPatchDocument<DevOpsWMSBugWorkItem> jsonPatch = new JsonPatchDocument<DevOpsWMSBugWorkItem>();
            DevOpsWMSBugWorkItem oBug = JsonConvert.DeserializeObject<DevOpsWMSBugWorkItem>(json);
            jsonPatch.Add(e => e.fields.SystemTitle, oBug.fields.SystemTitle);
            jsonPatch.Add(e => e.fields.SystemWorkItemType, oBug.fields.SystemWorkItemType);
            jsonPatch.Add(e => e.fields.MicrosoftVSTSTCMReproSteps, oBug.fields.MicrosoftVSTSTCMReproSteps);
            jsonPatch.Add(e => e.fields.CustomBackupName, oBug.fields.CustomBackupName);
            jsonPatch.Add(e => e.fields.MicrosoftVSTSCommonSeverity, oBug.fields.MicrosoftVSTSCommonSeverity);
            jsonPatch.Add(e => e.fields.CustomCustomer, oBug.fields.CustomCustomer);
            if (oBug.fields.SystemAssignedTo is not null)
                jsonPatch.Add(e => e.fields.SystemAssignedTo, oBug.fields.SystemAssignedTo);

            if (!String.IsNullOrEmpty(oBug.fields.CustomProcess))
                jsonPatch.Add(e => e.fields.CustomProcess, oBug.fields.CustomProcess);
            if (!String.IsNullOrEmpty(oBug.fields.CustomTimelogproject))
                jsonPatch.Add(e => e.fields.CustomTimelogproject, oBug.fields.CustomTimelogproject);
            if (!String.IsNullOrEmpty(oBug.fields.CustomFreshDesk))
                jsonPatch.Add(e => e.fields.CustomFreshDesk, oBug.fields.CustomFreshDesk);
            if (!String.IsNullOrEmpty(oBug.fields.CustomWorkdescription))
                jsonPatch.Add(e => e.fields.CustomWorkdescription, oBug.fields.CustomWorkdescription);
            if (!String.IsNullOrEmpty(oBug.fields.CustomApplication))
                jsonPatch.Add(e => e.fields.CustomApplication, oBug.fields.CustomApplication);
            if (!String.IsNullOrEmpty(oBug.fields.SystemIterationPath))
                jsonPatch.Add(e => e.fields.SystemIterationPath, oBug.fields.SystemIterationPath);

            try
            {
                var serializedDoc = JsonConvert.SerializeObject(jsonPatch);
                var data = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json-patch+json"));

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", _personalaccesstoken))));

                    using (HttpResponseMessage response = await client.PatchAsync(
                                $"", data))
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        response.EnsureSuccessStatusCode();

                        return responseBody;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        /*
         * This functions sends a GET request for various DevOps data which we can use in dropdowns menus on the client.
         * This includes all customers, processes, work descriptions and applications. 
        */
        [HttpGet("GetDevOpsBugData")]
        public async Task<string> GetDevOpsBugData()
        {
            string url = "";
            var responseBody = await GetDevOps(url);

            return responseBody;
        }
    }
}
