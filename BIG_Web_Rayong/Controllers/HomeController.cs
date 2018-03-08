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
                AboutUs = data.Where(x => x.SECTION_NAME == "About Us" && x.STATUS == 1).ToList(),
                SlideImage = data.Where(x => x.SECTION_NAME =="Slide Images" && x.STATUS ==1).OrderBy(o=> o.SEQ).ToList(),
                Branches = data.Where(x => x.SECTION_NAME == "Branches" && x.STATUS == 1).OrderBy(o => o.SEQ).ToList(),
                CEO = data.Where(x => x.SECTION_NAME == "CEO" && x.STATUS == 1).OrderBy(o => o.SEQ).ToList(),
                Mission = data.Where(x => x.SECTION_NAME == "Mission" && x.STATUS == 1).ToList(),
                Vision = data.Where(x => x.SECTION_NAME == "Vision" && x.STATUS == 1).ToList(),
                Policy = data.Where(x => x.SECTION_NAME ==  "Policy" && x.STATUS == 1).ToList()
            }; 
            return View(dataContent);
        }

    }
}