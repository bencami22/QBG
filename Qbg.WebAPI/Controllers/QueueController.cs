using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public QueueController(IQueueService queueService)
        {
            this.queueService = queueService;
        }

        // GET: api/Queue
        [HttpGet]
        public IEnumerable<QueueGet> Get()
        {
            return queueService.GetAll().Select(p => new QueueGet { Id = p.Id, TimeStamp = p.TimeStamp, Queue = (Queue<string>)p.Queue.Select(x => x.UserId.ToString()) });
        }

        // GET: api/Queue/5
        [HttpGet("{id}")]
        public async Task<QueueGet> Get(long id)
        {
            var qbgQueue = await queueService.GetQueueAsync(id);
            if (qbgQueue != null)
            {
                return new QueueGet { Id = qbgQueue.Id, TimeStamp = qbgQueue.TimeStamp, Queue = (Queue<string>)qbgQueue.Queue?.Select(p => p.UserId.ToString()) };
            }
            return null;
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
            var success=await queueService.EnqueueAsync(enqueueReq.Id, enqueueReq.UserName);
            if(success)
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
