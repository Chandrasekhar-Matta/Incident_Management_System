using IMS.Data;
using IMS.Services;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers
{

    [ApiController]
    [Route("api/workitems")]
    public class WorkItemController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IncidentService _service;

        public WorkItemController(AppDbContext db, IncidentService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.WorkItems.ToList());
        }

        [HttpPost("{id}/close")]
        public async Task<IActionResult> Close(int id)
        {
            try
            {
                await _service.Close(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}