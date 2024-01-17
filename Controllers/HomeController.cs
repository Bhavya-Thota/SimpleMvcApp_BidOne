using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace SimpleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                ViewBag.ErrorMessage = "Invalid data";
                return View("Index");
            }

            var formData = new FormData
            {
                FirstName = firstName,
                LastName = lastName
            };

            string json = JsonConvert.SerializeObject(formData);

            // Save to a file (you can customize the file path)
            string filePath = "formdata.json";
            System.IO.File.WriteAllText(filePath, json);

            ViewBag.SuccessMessage = "Data saved successfully";
            return View("Index");
        }
    }

    public class FormData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
