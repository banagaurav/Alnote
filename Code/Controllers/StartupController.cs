using Microsoft.AspNetCore.Mvc;

namespace Code.Controllers
{
    public class StartupController : Controller
    {
        // GET: StartupController
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(string Username, string Password)
        {
            // Handle sign-in logic here
            return RedirectToAction("Index", "Home"); // Redirect to home after successful login
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
