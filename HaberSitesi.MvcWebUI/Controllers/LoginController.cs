using FluentValidation.Results;
using HaberSitesi.Business.Concrete;
using HaberSitesi.Business.ValidationRules;
using HaberSitesi.DataAccess.Concrete.EntityFramework;
using HaberSitesi.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HaberSitesi.MvcWebUI.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        [HttpGet]
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Admin admin)
        {
            AdminValidator adminValidator = new AdminValidator();
            ValidationResult result = adminValidator.Validate(admin);
            var values = adminManager.GetByAdmin(admin.Email, admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Email, false);
                Session["Email"] = values.Email.ToString();
                return RedirectToAction("Haberler", "Admin");
            }
            else
            {
                if (!result.IsValid)
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        return View();
                    }
                }
                ViewBag.Error = "Kullanıcı adı veya şifre yanlış";
            }
            return View();
        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}