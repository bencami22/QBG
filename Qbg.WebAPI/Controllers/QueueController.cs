using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Qbg.IServices;
using Qbg.WebAPI.Models.Queue.Request;
using Qbg.WebAPI.Models.Queue.Response;

namespace Qbg.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Queue")]
    public class QueueController : Controller
    {
        IQueueService queueService;
        IMailUtility mailUtility;
        IConfiguration configuration;

        public QueueController(IQueueService queueService, IMailUtility mailUtility, IConfiguration configuration)
        {
            this.queueService = queueService;
            this.mailUtility = mailUtility;
            this.configuration = configuration;
        }

        // GET: api/Queue
        [HttpGet]
        public IEnumerable<QueueGet> Get()
        {
            var temp =queueService.GetAll().Select(p =>
            new QueueGet
            {
                Id = p.Id,
                TimeStamp = p.TimeStamp,
                Queue =  (List<QueueEntry>)p.Queue.Select(x => new QueueEntry { Username = x.User.Username.ToString(), TimeStamp = x.TimeStamp }).ToList()
            });
            return temp;
        }

        // GET: api/Queue/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var qbgQueue = await queueService.GetQueueAsync(id);
            if (qbgQueue != null)
            {
                return Ok(new QueueGet
                {
                    Id = qbgQueue.Id,
                    TimeStamp = qbgQueue.TimeStamp,
                 //   Queue = (List<QueueEntry>)qbgQueue.Queue.Select(x => new QueueEntry() { Username = x.User.Username.ToString(), TimeStamp = x.TimeStamp }).ToList()
                });
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // POST: api/Queue
        [HttpPost]
        public async Task<long> Post()
        {
            return (await queueService.InsertQueueAsync()).Id;
        }

        // POST: api/Queue
        [HttpGet("Dequeue")]
        public async Task<string> Dequeue(long id)
        {
            return (await queueService.DequeueAsync(id)).Username;
        }

        // POST: api/Queue
        [HttpPost("Enqueue")]
        public async Task<IActionResult> Enqueue([FromBody]QueueEnqueue enqueueReq)
        {
            var success = await queueService.EnqueueAsync(enqueueReq.Id, enqueueReq.UserName);
            if (success)
            {
                return StatusCode(StatusCodes.Status200OK);
            }
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            queueService.DeleteAsync(id);
        }
    }
}
