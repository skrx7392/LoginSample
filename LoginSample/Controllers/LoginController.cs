using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginService1;

namespace LoginSample.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(Models.UserLogin model)
        {
            LoginService1.Service1 service = new Service1();
            bool status = service.GetData(model.Email, model.Password);
            if(status)
            {
                Response.Write("<script>alert(\"Login Successful\")</script>");
            }
            else
                Response.Write("<script>alert(\"Login Failed\")</script>");
            return View("Login");
        }
    }
}