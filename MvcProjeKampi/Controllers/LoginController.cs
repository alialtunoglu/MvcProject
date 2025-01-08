using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        AdminLoginManager alm = new AdminLoginManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            // Kullanıcı doğrulama işlemi
            if (alm.ValidateAdmin(p.AdminUserName, p.AdminPassword))
            {
                FormsAuthentication.SetAuthCookie(p.AdminUserName, false);
                Session["AdminUserName"] = p.AdminUserName; // Oturum açma işlemi
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }
    }
}