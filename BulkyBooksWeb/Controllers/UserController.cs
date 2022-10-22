using BulkyBooks.DataAccess;
using BulkyBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext Db)
        {
            _db = Db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> userList = _db.Users;
            return View(userList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
