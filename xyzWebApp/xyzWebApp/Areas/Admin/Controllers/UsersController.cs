using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using xyzWebApp.Areas.Identity.Data;
using xyzWebApp.Models;

namespace xyzWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;

        public UsersController(UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;

        }

        // GET: UsersController
        public async Task<IActionResult> Index()
        {
            return View(_userManager.Users.ToList());
        }

        // GET: UsersController/Create
        [HttpGet]
        public ActionResult Create()
        {
            //ViewBag.ErrorMsg = TempData["ErrorMsg"];
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser
                {
                    UserName = user.Name,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };

                var newUser = await _userManager.CreateAsync(appUser, user.Password);
                newUser = await _userManager.AddToRoleAsync(appUser, "Customer");

                if (newUser.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    foreach (IdentityError error in newUser.Errors)
                        ModelState.AddModelError("", error.Description);
                }

            }

            return View(user);
        }

        // GET: UsersController/Edit/5
        public async Task<IActionResult> Update(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if(user != null)
                return View(user);
            else 
                return RedirectToAction("Index");
            
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string id, string email, string password, string firstName, string lastName, int roles)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if( user != null )
            {
                if (!String.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email can't be empty!");

                if (!String.IsNullOrEmpty(password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password can't be empty!");

                if(!String.IsNullOrEmpty(firstName))
                    user.FirstName = firstName;
                else
                    ModelState.AddModelError("", "Enter first name.");

                if (!String.IsNullOrEmpty(lastName))
                    user.LastName = lastName;
                else
                    ModelState.AddModelError("", "Enter last name");

                if(roles != 0)
                {
                    if (roles == 2)
                        await _userManager.AddToRoleAsync(user, "Admin");


                    else if (roles == 1)
                        await _userManager.AddToRoleAsync(user, "Customer");

                    else
                        ModelState.AddModelError("", "User role can't be recognised!");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user role!");
                }


                if(!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(firstName) && !                 String.IsNullOrEmpty(lastName))
                {
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                        return RedirectToAction("Index");

                    else
                    {
                        foreach (IdentityError error in result.Errors)
                            ModelState.AddModelError("", error.Description);
                    }
                }
            }

            else
                ModelState.AddModelError("", "User not found!");

            return View(user);

        }

        // GET: UsersController/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            

            if(id == null || _userManager.Users == null)
            {
                return NotFound();
            }

            ApplicationUser user = await _userManager.FindByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: UsersController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);

            if(user != null )
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Index");

                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }

            else
                ModelState.AddModelError("", "User not found!");

            return RedirectToAction("Index");
        }
    }
}
