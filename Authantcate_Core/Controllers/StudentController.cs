using Authantcate_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Authantcate_Core.Controllers
{
    public class StudentController : Controller
    {
        private readonly DatabaseContext context;
        public StudentController(DatabaseContext context)
        {
            this.context = context;
        }
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(user_tbl _user)
        {
            if (ModelState.IsValid)
            {
               await context.Users.AddAsync(_user);
               await context.SaveChangesAsync();
               TempData["sucess"] = "Register SuccessFully!";
               return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                return RedirectToAction("Dashboard");

            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(user_tbl _Tbl)
        {
            var myuser = context.Users.Where(x => x.Email == _Tbl.Email && x.Password == _Tbl.Password).FirstOrDefault();
            if(myuser != null)
            {
                HttpContext.Session.SetString("usersession", _Tbl.Email);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.Message = "Login Failed...";
            }
            return View();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                ViewBag.session = HttpContext.Session.GetString("usersession");
                
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                HttpContext.Session.Remove("usersession");
                return RedirectToAction("Login");

            }
            return View();
        }



    }
}
