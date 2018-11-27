using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Qbg.ngWebApp.Models.Queue.Request;
using Qbg.ngWebApp.Models.Queue.Response;

namespace Qbg.ngWebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QueueController : Controller
    {
        private readonly string url = "http://localhost:51173";

        static HttpClient client = new HttpClient();

        // GET: api/Queue
        [HttpGet]
        public async Task<IEnumerable<QueueGet>> Get()
        {
            var response = await client.GetAsync($"{url}/api/queue");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<QueueGet>>(await response.Content.ReadAsStringAsync());
        }

        // GET: api/Queue/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<QueueGet> Get(int id)
        {
            var response = await client.GetAsync($"{url}/api/queue/{id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<QueueGet>(await response.Content.ReadAsStringAsync());
        }

        [HttpPost("Enqueue")]
        public async Task<IActionResult> Enqueue([FromBody]QueueEnqueue enqueueReq)
        {
            var buffer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(enqueueReq));
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync($"{url}/api/queue/Enqueue", byteContent);
            return StatusCode((int)response.StatusCode);
        }


        [HttpPost("Dequeue")]
        public async Task<IActionResult> Dequeue(long id)
        {
            var response = await client.PostAsync($"{url}/api/queue/Dequeue?id={id}", null);
            return StatusCode((int)response.StatusCode);
        }
        
        // POST: api/Queue
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var response = await client.PostAsync($"{url}/api/queue", null);
            return StatusCode((int)response.StatusCode);
        }

        // PUT: api/Queue/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await client.DeleteAsync($"{url}/api/queue/{id}");
            return StatusCode((int)response.StatusCode);
        }
    }
}
