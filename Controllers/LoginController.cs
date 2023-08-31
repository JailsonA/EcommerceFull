using EcommerceFull.Data;
using EcommerceFull.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace EcommerceFull.Controllers
{
    public class LoginController : Controller
    {
        private readonly DBAutent _dbAutent;
        public LoginController(DBAutent dBAutent)
        {
            _dbAutent = dBAutent;
        }
        public IActionResult Index()
        {
            string isLog = HttpContext.Session.GetString("isLog");
            if (isLog != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult IsLogin(LoginModel login)
        {
            try
            {
                if (!ModelState.IsValid) return View("Index");


                UserModel user = _dbAutent.VerifLogin(login.UserEmail, login.UserPass);
                if (user == null) return View("Index");

                HttpContext.Session.SetString("isLog", user.UserName);
                HttpContext.Session.SetString("Email", user.UserEmail);
                HttpContext.Session.SetString("UserID", user.UserID.ToString());

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult TesteLogin()
        {
            return View();
        }
    }
}
