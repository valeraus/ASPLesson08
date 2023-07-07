using Microsoft.AspNetCore.Mvc;
using Task01.Models;

namespace Task01.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(RegistrationFormModel form)
        {
            if (ModelState.IsValid)
            {
                if (form.Product == "Основи" && form.DesiredConsultationDate.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("DesiredConsultationDate", "Консультація щодо продукту «Основи» не може проходити по понеділках");
                    return View(form);
                }

                return RedirectToAction("Success");
            }

            return View(form);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
