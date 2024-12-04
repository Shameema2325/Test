using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    public class UserController : Controller
    {

        private static readonly List<Usercs> FormDataList = new List<Usercs>();

        // GET: Form
        public ActionResult Index()
        {
            // Pass the data list to the view
            return View(FormDataList);
        }

        // POST: Form/Submit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Submit(Usercs user)
        {
            // Validate the model
            if (ModelState.IsValid)
            {
                // Add the data to the in-memory list
                FormDataList.Add(user);

                // Redirect to the Index page to show the list
                return RedirectToAction("Index");
            }

            // If validation fails, return the same view with the model
            return View("Index", FormDataList);
        }

        // GET: Form/Delete/{id}
        public ActionResult Delete(int id)
        {
            var item = FormDataList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                FormDataList.Remove(item);
            }
            return RedirectToAction("Index");
        }

        // GET: Form/Edit/{id}
        public ActionResult Edit(int id)
        {
            var item = FormDataList.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Index");
        }

        // POST: Form/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usercs updatedData)
        {
            var item = FormDataList.FirstOrDefault(x => x.Id == updatedData.Id);
            if (item != null && ModelState.IsValid)
            {
                // Update the existing item
                item.TextBox = updatedData.TextBox;
                item.NumericBox = updatedData.NumericBox;
                item.MaskedBox = updatedData.MaskedBox;
                item.DatePicker = updatedData.DatePicker;
                item.DateTimePicker = updatedData.DateTimePicker;
                item.SwitchInput = updatedData.SwitchInput;
                item.ComboBox = updatedData.ComboBox;

                return RedirectToAction("Index");
            }
            return View(updatedData);
        }
    }
}
