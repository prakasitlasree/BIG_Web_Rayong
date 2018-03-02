using BIG.WEB.RY.DATASERVICE;
using BIG.WEB.RY.MODEL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BIG_Web_Rayong.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult HomeManagement()
        {
            var xx = Session["Login"];
            if (Session["Login"] == null)
            {
               return RedirectToAction("Index", "Login");
            }
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();

            Content dataContent = new Content()
            {
                AboutUs = data.Where(x => x.SECTION_NAME == "About Us").ToList(),
                SlideImage = data.Where(x => x.SECTION_NAME == "Slide Images").ToList(),
                Branches = data.Where(x => x.SECTION_NAME == "Branches").ToList(),
                CEO = data.Where(x => x.SECTION_NAME == "CEO").ToList(),
                Mission = data.Where(x => x.SECTION_NAME == "Mission").ToList(),
                Vision = data.Where(x => x.SECTION_NAME == "Vision").ToList(),
                Policy = data.Where(x => x.SECTION_NAME == "Policy").ToList()


            };



            return View(dataContent);
        }

        public ActionResult CustomerManagement()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
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

        public ActionResult QualityManagement()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();

            Content dataContent = new Content()
            {
                Quality = data.Where(x => x.SECTION_NAME == "Quality").ToList(),
             

            };
            return View(dataContent);

        }

        public ActionResult NewsManagement()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();

            Content dataContent = new Content()
            {
                News = data.Where(x => x.SECTION_NAME == "News").ToList(),


            };
            return View(dataContent);

        }
        public ActionResult JoinUsManagement()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();

            Content dataContent = new Content()
            {
                 JoinUs = data.Where(x => x.SECTION_NAME == "JoinUs").ToList(),


            };
            return View(dataContent);

        }

        public ActionResult ServiceManagement()
        {
            if (Session["Login"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();

            Content dataContent = new Content()
            {
                Services = data.Where(x => x.SECTION_NAME == "Service").ToList(),


            };
            return View(dataContent);

        }
        public ActionResult SaveDataImageSlide(Content dataInput, string type)
        {

            type = dataInput.PageContent.AUTO_ID > 0 ? "Edit" : "Add";
            dataInput.PageContent.SECTION_NAME = "Slide Images";
            dataInput.PageContent.TYPE_ID = 1;
            if(dataInput.PageContentUpload != null)
            {
                var file = dataInput.PageContentUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/Content/Banner"));

                if (!Directory.Exists(Server.MapPath("~/Content/Banner")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Content/Banner"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Content/Banner"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageContent.IMAGE_URL = "/Content/Banner/" + fileName;
            }
            Result resultTrans;
            if(type == "Add")
            {
                dataInput.PageContent.CREATED_BY = ((LOGON)Session["Login"]).USERNAME;
                resultTrans = new PageContent_Services().AddPageContent(dataInput.PageContent);
            }
            else
            {
                dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
                resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            }
            return resultTrans.Status == true ? RedirectToAction("HomeManagement", "Admin") : null;
        }

        public ActionResult SaveDataAboutUs(Content dataInput)
        {
            dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
            dataInput.PageContent.SECTION_NAME = "About Us";
            dataInput.PageContent.TYPE_ID = 1;
            if (dataInput.PageContentUpload != null)
            {
                var file = dataInput.PageContentUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/big_img"));

                if (!Directory.Exists(Server.MapPath("~/big_img")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/big_img"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/big_img"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageContent.IMAGE_URL = "/big_img/" + fileName;
            }
            Result resultTrans;
          
                resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            return resultTrans.Status == true ? RedirectToAction("HomeManagement", "Admin") : null;
        }

        public ActionResult SaveDataQuality(Content dataInput)
        {
            dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
            dataInput.PageContent.SECTION_NAME = "Quality";
            dataInput.PageContent.TYPE_ID = 4;
            if (dataInput.PageContentUpload != null)
            {
                var file = dataInput.PageContentUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/big_img"));

                if (!Directory.Exists(Server.MapPath("~/big_img")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/big_img"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/big_img"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageContent.IMAGE_URL = "/big_img/" + fileName;
            }
            Result resultTrans;

            resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            return resultTrans.Status == true ? RedirectToAction("QualityManagement", "Admin") : null;
        }

        public ActionResult SaveDataNews(Content dataInput ,string type)
        {
            type = dataInput.PageContent.AUTO_ID > 0 ? "Edit" : "Add";
            dataInput.PageContent.SECTION_NAME = "News";
            dataInput.PageContent.TYPE_ID = 6;
            if (dataInput.PageContentUpload != null)
            {
                var file = dataInput.PageContentUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/CSR"));

                if (!Directory.Exists(Server.MapPath("~/CSR")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/CSR"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/CSR"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageContent.IMAGE_URL = "/CSR/" + fileName;
            }
            Result resultTrans;
            if (type == "Add")
            {
                dataInput.PageContent.CREATED_BY = ((LOGON)Session["Login"]).USERNAME;
                resultTrans = new PageContent_Services().AddPageContent(dataInput.PageContent);
            }
            else
            {
                dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
                resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            }
            return resultTrans.Status == true ? RedirectToAction("NewsManagement", "Admin") : null;
        }

        public ActionResult SaveDataJoinUs(Content dataInput, string type)
        {
            type = dataInput.PageContent.AUTO_ID > 0 ? "Edit" : "Add";
            dataInput.PageContent.SECTION_NAME = "JoinUs";
            dataInput.PageContent.TYPE_ID = 7;
            if (dataInput.PageContentUpload != null)
            {
                var file = dataInput.PageContentUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/big_img"));
                dataInput.PageContent.HTML_SUB_HEADER1 = "รูปภาพ";
                if (!Directory.Exists(Server.MapPath("~/big_img")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/big_img"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/big_img"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageContent.IMAGE_URL = "/big_img/" + fileName;
            }
            Result resultTrans;
            if (type == "Add")
            {
                dataInput.PageContent.CREATED_BY = ((LOGON)Session["Login"]).USERNAME;
                resultTrans = new PageContent_Services().AddPageContent(dataInput.PageContent);
            }
            else
            {
                dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
                resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            }
            return resultTrans.Status == true ? RedirectToAction("JoinUsManagement", "Admin") : null;
        }

        public ActionResult SaveDataCEO(Content dataInput)
        {
            dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
            dataInput.PageContent.SECTION_NAME = "CEO";
            dataInput.PageContent.TYPE_ID = 1;
            if (dataInput.PageContentUpload != null)
            {
                var file = dataInput.PageContentUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/big_img"));

                if (!Directory.Exists(Server.MapPath("~/big_img")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/big_img"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/big_img"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageContent.IMAGE_URL = "/big_img/" + fileName;
            }
            Result resultTrans;

            resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            return resultTrans.Status == true ? RedirectToAction("HomeManagement", "Admin") : null;
        }

        public ActionResult SaveDataBranches(Content dataInput)
        {
            dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
            dataInput.PageContent.SECTION_NAME = "Branches";
            dataInput.PageContent.TYPE_ID = 1;
            Result resultTrans;
            resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            return resultTrans.Status == true ? RedirectToAction("HomeManagement", "Admin") : null;
        }

        public ActionResult SaveDataService(Content dataInput)
        {
            dataInput.PageContent.UPDATED_BY = ((LOGON)Session["Login"]).USERNAME;
            dataInput.PageContent.SECTION_NAME = "Service";
            dataInput.PageContent.TYPE_ID = 2;
            Result resultTrans;
            resultTrans = new PageContent_Services().EditPageContent(dataInput.PageContent);
            return resultTrans.Status == true ? RedirectToAction("ServiceManagement", "Admin") : null;
        }
        public ActionResult DeletePageContent(int id)
        {
            PAGE_CONTENT dataInput = new PAGE_CONTENT()
            {
                AUTO_ID = id

            };
            PageContent_Services service = new PageContent_Services();
            var data = service.GetAll().ToList();
            int? section = data.Where(x => x.AUTO_ID == id).First().TYPE_ID;
            string controller = "";
            switch (section)
            {
                case 1:
                    controller = "HomeManagement";
                    break;
                case 2:
                    controller = "ServiceManagement";
                    break;
                case 4:
                    controller = "QualityManagement";
                    break;
                case 6:
                    controller = "NewsManagement";
                    break;
                case 7:
                    controller = "JoinUsManagement";
                    break;
                default:
                    controller = "HomeManagement";
                    break;
            }

            var resultTrans = new PageContent_Services().DeletePageContent(dataInput);
          
           return resultTrans.Status == true ? RedirectToAction(controller, "Admin") : null;
        }

        public ActionResult SaveDataCustomer(Content dataInput, string type)
        {
            type = dataInput.PageCustomer.AUTO_ID > 0 ? "Edit" : "Add";
            if (dataInput.PageCustomerUpload != null)
            {
                var file = dataInput.PageCustomerUpload;
                var fileName = Path.GetFileName(file.FileName);
                var files = Directory.GetFiles(Server.MapPath("~/customer_img"));

                if (!Directory.Exists(Server.MapPath("~/customer_img")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/customer_img"));
                }
                var exist = (from p in files
                             where p.Contains(fileName)
                             select p).ToList();
                if (exist.Count > 0)
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + exist.Count + exist.Count + Path.GetExtension(fileName);
                }
                if (file != null && file.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/customer_img"), fileName);
                    file.SaveAs(path);
                }
                dataInput.PageCustomer.LOGO_URL = "/customer_img/" + fileName;
            }
            Result resultTrans;
            if (type == "Add")
            {
                resultTrans = new Customer_Services().AddPageCustomer(dataInput.PageCustomer);
            }
            else
            {
                resultTrans = new Customer_Services().EditPageCustomer(dataInput.PageCustomer);
            }
            return resultTrans.Status == true ? RedirectToAction("CustomerManagement", "Admin") : null;
        }

        public ActionResult DeletePageCustomer(int id)
        {
            PAGE_CUSTOMER dataInput = new PAGE_CUSTOMER()
            {
                AUTO_ID = id

            };
            var resultTrans = new Customer_Services().DeletePageCustomer(dataInput);
            return resultTrans.Status == true ? RedirectToAction("CustomerManagement", "Admin") : null;
        }
    }
}