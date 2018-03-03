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
            var service = new PageContent_Services();
            var data = service.GetAll().ToList();
     
            Content dataContent = new Content()
            {

                 AboutUs = data.Where(x => x.SECTION_NAME == "About Us").Where(x=>x.STATUS == 1).ToList(),
                SlideImage = data.Where(x => x.SECTION_NAME =="Slide Images").Where(x => x.STATUS == 1).ToList(),
                Branches = data.Where(x => x.SECTION_NAME == "Branches").ToList(),
                CEO = data.Where(x => x.SECTION_NAME == "CEO").Where(x => x.STATUS == 1).ToList(),
                Mission = data.Where(x => x.SECTION_NAME == "Mission").ToList(),
                Vision = data.Where(x => x.SECTION_NAME == "Vision").ToList(),
                Policy = data.Where(x => x.SECTION_NAME ==  "Policy").ToList()
            };



            return View(dataContent);
        }

    }
}