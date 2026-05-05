using IMS.Data;
using IMS.Models;
using IMS.Queue;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controllers
{
    [ApiController]
    [Route("api/signals")]
    public class SignalController : ControllerBase
    {
        private readonly SignalQueue _queue;

        public SignalController(SignalQueue queue)
        {
            _queue = queue;
        }
        

        [HttpPost]
        public async Task<IActionResult> Post(Signal signal)
        {
            await _queue.Enqueue(signal);
            return Accepted();
        }
    }
}