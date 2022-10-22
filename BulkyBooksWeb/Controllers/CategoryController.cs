using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksWeb.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
