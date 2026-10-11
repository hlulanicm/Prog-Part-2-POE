using API_proj.Data;
using API_proj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace API_Proj.Controllers

    //Importing all necessarry assets 

    {
namespace API_proj.Controllers
    {
        [ApiController]
        [Route("api")]
        [Authorize] // every endpoint requires a logged-in user that is registered
        public class CategoriesController : ControllerBase
        {
            private readonly ApplicationDBContext _context;

            public CategoriesController(ApplicationDBContext context)
            {
                _context = context; // Assigning context to a context container 
            }

         private int CurrentUserId =>

           int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            /// Lists the race categories for an event. Available to both roles
            [HttpGet("events/{id}/categories")]


            //listing the Types of responses on the API Endpoint can produce  
            [ProducesResponseType(typeof(List<Category>), StatusCodes.Status200OK)] 
              [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public async Task<ActionResult<List<Category>>> GetEventCategories(int id)
            {
                var categories = await _context.Categories.AsNoTracking()
                    .Where(c => c.EventID == id)
                    .ToListAsync();
                //if the category is not found display an appropriate message
                return categories.Count == 0 ? NotFound("Category not found.") : Ok(categories);
            }
        }
