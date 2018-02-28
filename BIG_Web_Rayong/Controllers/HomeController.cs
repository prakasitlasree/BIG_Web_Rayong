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
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();
     
            Content dataContent = new Content()
            {

                 AboutUs = data.Where(x => x.SECTION_NAME == "About Us").ToList(),
                SlideImage = data.Where(x => x.SECTION_NAME =="Slide Images").ToList(),
                Branches = data.Where(x => x.SECTION_NAME == "Branches").ToList(),
                CEO = data.Where(x => x.SECTION_NAME == "CEO").ToList(),
                Mission = data.Where(x => x.SECTION_NAME == "Mission").ToList(),
                Vision = data.Where(x => x.SECTION_NAME == "Vision").ToList(),
                Policy = data.Where(x => x.SECTION_NAME ==  "Policy").ToList()
            };



            return View(dataContent);
        }

    }
}