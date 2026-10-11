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
        }
