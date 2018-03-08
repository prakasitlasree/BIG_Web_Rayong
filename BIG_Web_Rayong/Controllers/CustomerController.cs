using BIG.WEB.RY.DATASERVICE;
using BIG.WEB.RY.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIG_Web_Rayong.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        { 
            var service = new PageContent_Services();
            var serviceCust = new Customer_Services();
            var dataContent = new Content();
            dataContent.Customers = service.GetAll().Where(x => x.SECTION_NAME == "Customer").OrderBy(o => o.SEQ).ToList();
            dataContent.CustomerList = serviceCust.GetAll();
            return View(dataContent);
        }
    }
}