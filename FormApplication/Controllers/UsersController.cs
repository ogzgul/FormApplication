using FormApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Web;

namespace FormApplication.Controllers
{
    public class UsersController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;
        public UsersController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View(_signInManager.UserManager.Users);
        }
        public IActionResult Create()
        {

            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,UserName,Password,ConfirmPassword")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _signInManager.UserManager.CreateAsync(applicationUser, applicationUser.Password).Wait();
                return Redirect("~/");

            }
            return View(applicationUser);
        }



        public IActionResult Login(string ReturnUrl = null, string error = null)
        {
            ViewData["returnUrl"] = ReturnUrl;
            ViewData["LoginFlag"] = error;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void Login(string userName, string password, string? returnUrl, string? error)
        {
            Microsoft.AspNetCore.Identity.SignInResult identityResult;

            if (ModelState.IsValid)
            {
                var users = _signInManager.UserManager.FindByNameAsync(userName).Result;
                if (users != null)
                {

                    Response.Redirect("/");
                }
                identityResult = _signInManager.PasswordSignInAsync(userName, password, false, false).Result;
                if (identityResult.Succeeded == true)
                {
                    Response.Redirect("/Members/Index");
                }
                else
                {
                    string encodedUrl = HttpUtility.UrlEncode(returnUrl);

                    Response.Redirect("/Users/Login?error=Kullan%c4%b1c%c4%b1+Ad%c4%b1+veya+Parola+Hatal%c4%b1&ReturnUrl=" + encodedUrl);

                    //Response.Redirect("/Login");
                }
            }
            Response.Redirect("/Members/Index");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Users/Login");
        }
    }
}
