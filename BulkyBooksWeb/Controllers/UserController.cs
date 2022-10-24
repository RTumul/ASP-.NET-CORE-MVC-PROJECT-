using BulkyBooks.DataAccess;
using BulkyBooks.DataAccess.Repository.IRepository;
using BulkyBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _db;

        public UserController(IUserRepository Db)
        {
            _db = Db;
        }
        public IActionResult Index()
        {
            IEnumerable<User> userList = _db.GETAll();
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
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "User Created Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "There is something wrong";
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.GetFirstOrDefault(u=>u.Id==id);
            if(userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "User Updated Successfully";
                return RedirectToAction("Index");
            }
            TempData["error"] = "There is something wrong";
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _db.GetFirstOrDefault(u=>u.Id==id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u=>u.Id==id);
            if (obj != null) 
            {
                _db.Remove(obj);
                _db.Save();
                TempData["success"] = "User Deleted Successfully";
                return RedirectToAction("Index");
            }
               
            
            TempData["error"] = "There is something wrong";
            return View(obj);
        }
    }
}
