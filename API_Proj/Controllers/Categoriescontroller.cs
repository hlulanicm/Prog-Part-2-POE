using API_proj.Data;
using API_proj.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
namespace API_Proj.Controllers

    //Importing all necessarry assets 
{
    public class Categoriescontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
