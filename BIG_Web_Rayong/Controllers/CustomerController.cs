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
            PageContent_Services service = new PageContent_Services();
            Customer_Services serviceCust = new Customer_Services();
            var data = service.GetAll().ToList();
            var listCust = serviceCust.GetAll();
            
            Content dataContent = new Content()
            {
                Customers = data.Where(x => x.SECTION_NAME == "Customer").ToList(),
                CustomerList = listCust
            };
            return View(dataContent);
        }
    }
}