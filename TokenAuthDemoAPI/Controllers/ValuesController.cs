using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using TokenAuthDemoAPI.Models;

namespace TokenAuthDemoAPI.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        [Route("api/async-values")]
        public async Task<IEnumerable<GitUser>> GetAsync()
        {
            return await GetExternalResponse();
        }

        [AllowAnonymous]
        [Route("api/async-values-noauth")]
        public async Task<IEnumerable<GitUser>> GetAsyncNoAuth()
        {
            return await GetExternalResponse();
        }

        private async Task<IEnumerable<GitUser>> GetExternalResponse()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.github.com/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", "C# App");

            HttpResponseMessage response = await httpClient.GetAsync("users");

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var result = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<GitUser>>(content));

            return result;
        }
    }
}
