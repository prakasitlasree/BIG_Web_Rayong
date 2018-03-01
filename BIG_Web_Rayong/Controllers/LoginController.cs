using BIG.WEB.RY.MODEL;
using BIG.WEB.RY.DATASERVICE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIG_Web_Rayong.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if(Session["Login"] != null)
            {
                return RedirectToAction("HomeManagement", "Admin");
            }
        
            return View();
        }
        public ActionResult Login(LOGON account)
        {
            LogOn_Services service = new LogOn_Services();
            var logon = service.GetAll();
            var verifyId = logon.Where(x => x.USERNAME == account.USERNAME).Count();
            if(verifyId > 0)
            {
                var verifyPass = logon.Where(x => x.PASSWORD == account.PASSWORD).Count();
                if(verifyPass > 0)
                {
                    Session["Login"] = account;
                    return RedirectToAction("HomeManagement", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }


          
        }
    }
}