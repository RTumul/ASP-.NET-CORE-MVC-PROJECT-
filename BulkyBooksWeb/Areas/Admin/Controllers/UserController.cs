using BulkyBooks.DataAccess;
using BulkyBooks.DataAccess.Repository;
using BulkyBooks.DataAccess.Repository.IRepository;
using BulkyBooks.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBooksWeb.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<User> userList = _unitOfWork.User.GETAll();
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
                _unitOfWork.User.Add(obj);
                _unitOfWork.Save();
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
            var userFromDb = _unitOfWork.User.GetFirstOrDefault(u=>u.Id==id);
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
                _unitOfWork.User.Update(obj);
                _unitOfWork.Save();
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
            var userFromDb = _unitOfWork.User.GetFirstOrDefault(u=>u.Id==id);
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
            var obj = _unitOfWork.User.GetFirstOrDefault(u=>u.Id==id);
            if (obj != null) 
            {
                _unitOfWork.User.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "User Deleted Successfully";
                return RedirectToAction("Index");
            }
               
            
            TempData["error"] = "There is something wrong";
            return View(obj);
        }
    }
}
