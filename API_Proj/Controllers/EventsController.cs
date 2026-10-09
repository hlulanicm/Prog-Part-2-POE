using API_proj.Data;
using API_Proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EventsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_context.Events.ToList());
        }

        [HttpPost]
        public IActionResult CreateEvent(Event newEvent)
        {
            _context.Events.Add(newEvent);
            _context.SaveChanges();
            return Ok(newEvent);
        }
    }
}