using Microsoft.AspNetCore.Mvc;
using IMS.Data;
using IMS.Models;

namespace IMS.Controllers
{

    [ApiController]
    [Route("api/rca")]
    public class RCAController : ControllerBase
    {
        private readonly AppDbContext _db;

        public RCAController(AppDbContext db)
        {
            _db = db;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.RCAs.ToList());
        }

       

        [HttpPost]
        public async Task<IActionResult> Add(RCA rca)
        {
            _db.RCAs.Add(rca);
            await _db.SaveChangesAsync();
            return Ok();
        }

       
    }
}