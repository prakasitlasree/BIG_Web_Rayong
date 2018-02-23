using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIG.WEB.RY.DATASERVICE;
using BIG.WEB.RY.MODEL;

namespace BIG_Web_Rayong.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LogOn_Services service = new LogOn_Services();
            var x = service.GetAll();
            return View();
        }

    }
}