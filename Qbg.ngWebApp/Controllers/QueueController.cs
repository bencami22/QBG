﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        // POST: api/Queue
        [HttpPost]
        public void Post([FromBody]string value)
        {
            // new StringContent(jsonInString, Encoding.UTF8, "application/json")
        }

        // PUT: api/Queue/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
