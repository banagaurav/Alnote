using Microsoft.AspNetCore.Mvc;
using Code.Models; // Assuming you have ApplicationUser here
using Code.ViewModels; // Assuming LoginViewModel is defined here
using Microsoft.EntityFrameworkCore;

namespace Code.Controllers
{
    public class StartupController : Controller
    {
        private readonly AppDbContext _context;

        public StartupController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SignIn page
        public ActionResult SignIn()
        {
            return View();
        }

        // POST: SignIn page - Handle login logic
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find user by username or email
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.Username || u.Email == model.Username);

                if (user != null)
                {
                    // Compare the stored password with the entered password
                    if (user.Password == model.Password) // Simple comparison (no hashing)
                    {
                        // Password matched, user can be logged in
                        // Typically you'd issue a cookie or a JWT here, but for simplicity, we'll just redirect to Home
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Password does not match
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    // User not found
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }

            // If we reach here, something failed, return to the same view with validation errors
            return View(model);
        }



        // Register page (still to be implemented)
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: SignUp page - Handle registration logic
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserName == model.UserName || u.Email == model.Email);

                if (existingUser != null)
                {
                    ModelState.AddModelError(string.Empty, "Username or email is already taken.");
                    return View(model);
                }

                var newUser = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password, // Note: Do not store plain text passwords, you should hash the password
                    Role = model.Role
                };

                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); // Redirect to a home page after successful registration
            }

            return View(model); // Return the view with validation errors if the model is invalid
        }
    }
}
