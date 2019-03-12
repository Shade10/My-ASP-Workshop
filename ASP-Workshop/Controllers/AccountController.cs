using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ASP_Workshop.Infrastructure.Abstract;
using ASP_Workshop.Models;

namespace ASP_Workshop.Controllers
{
    public class AccountController : Controller
    {
        public IAuthProvider authProvider;

        public AccountController(IAuthProvider auth) {
            authProvider = auth;
        }

        // GET: Account
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            if (ModelState.IsValid) {
                if (authProvider.Authenticate(model.UseName, model.Password)) {
                    return Redirect(returnUrl ?? Url.Action("Index", "Home"));
                } else {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło");
                }

                return View();
            } else {
                return View();
            }
        }
        
    }
}