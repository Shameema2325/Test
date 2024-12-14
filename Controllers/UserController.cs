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
                    return RedirectToAction("UsersLoad", "Display");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;
                return RedirectToAction("InsertLoad","Display");
            }
           
        }

    }
}
