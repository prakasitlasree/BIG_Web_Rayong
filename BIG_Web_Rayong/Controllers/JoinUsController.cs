﻿using BIG.WEB.RY.DATASERVICE;
using BIG.WEB.RY.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIG_Web_Rayong.Controllers
{
    public class JoinUsController : Controller
    {
        // GET: JoinUs
        public ActionResult Index()
        {
            var service = new PageContent_Services();
            var data = service.GetAll().ToList();

            Content dataContent = new Content()
            {
                JoinUs = data.Where(x => x.SECTION_NAME == "JoinUs" && x.STATUS == 1).OrderBy(o => o.SEQ).ToList(), 
            };
            return View(dataContent);
        }
    }
}