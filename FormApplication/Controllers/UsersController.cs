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
                    

                    Response.Redirect("/Users/Login?error="+ UrlEncode("Kullanıcı adı veya şifre hatalı"));

                    //Response.Redirect("/Login");
                }

            }
            else
            {

                Response.Redirect("/Users/Login?error=" + UrlEncode("Kullanıcı Adı ve Şifre Zorunludur"));
            }
            
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Users/Login");
        }


        private string UrlEncode(string text)
        {
            string encodedUrl = HttpUtility.UrlEncode(text);

            return encodedUrl;

        }
    }
}
