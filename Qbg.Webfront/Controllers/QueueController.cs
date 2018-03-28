using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Qbg.Webfront.ViewModels;

namespace Qbg.Webfront.Controllers
{
    public class QueueController : Controller
    {
        public IActionResult Display()
        {
            QueueDisplay viewModel = new QueueDisplay()
            {
                CurrentTime = DateTime.Now,

                //TODO: Get Data
                //Testing Data
                Serving = "1",
                NextUpList = new List<string>() { "2", "3" }
            };
            return View(viewModel);
        }
        
        public IActionResult AddToQueue()
        {
            //TODO: Add person to queue on DB
            return RedirectToAction("Display");
        }
    }
}