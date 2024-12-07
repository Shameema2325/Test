using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using Test.Models;

namespace Test.Controllers
{

    public class DisplayController : Controller
    {
        UserDB userDB = new UserDB();
        public IActionResult UsersLoad(User user)
        {
            List<User> employeesList = userDB.DisplayAll(user);
            return View(employeesList);
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
            return RedirectToAction("UsersLoad", "Display");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var result = userDB.Delete(id);  
                TempData["Msg"] = result;
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;  
            }

            return RedirectToAction("UsersLoad", "Display");
        }
    }
}
