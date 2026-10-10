using Microsoft.AspNetCore.Mvc;

namespace API_Proj.Controllers
{
    public class Categoriescontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
