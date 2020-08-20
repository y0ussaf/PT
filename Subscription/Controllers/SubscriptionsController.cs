using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Subscription.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        public SubscriptionsController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscription()
        {
            return  Ok();
        }
        
    }
}