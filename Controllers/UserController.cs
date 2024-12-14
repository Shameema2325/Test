using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {
        UserDB userDB = new UserDB();
        public IActionResult InsertLoad()
        {             
            return View();
        }

        [HttpPost]
        public IActionResult Insert(User user)
        {
            try
            {
                    var result = userDB.Insert(user);
                    TempData["Msg"] = result;
                    return RedirectToAction("UsersLoad", "User");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;
                return RedirectToAction("InsertLoad","User");
            }
           
        }

        public IActionResult UsersLoad(User user)
        {
            List<User> userList = userDB.DisplayAll(user);
            return View(userList);
        }

        public IActionResult Edit(int id)
        {
            var user = userDB.Display(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var result = userDB.Edit(user);
                TempData["Msg"] = result;
            }
            return RedirectToAction("UsersLoad", "User");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = userDB.Delete(id);
                TempData["Msg"] = result;
                return RedirectToAction("UsersLoad", "User");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;
            }

            return RedirectToAction("UsersLoad", "User");
        }

    }
}
