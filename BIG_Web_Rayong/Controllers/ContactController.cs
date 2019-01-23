using BIG.WEB.RY.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BIG_Web_Rayong.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult SendEmail(EmailContent dataInput)
        {
            Result result = new Result();
            try
            { 
                SmtpClient mailServer = new SmtpClient("smtp.gmail.com", 587);
                mailServer.EnableSsl = true;
                mailServer.UseDefaultCredentials = false;
                
                var mailTo = "siriporn.marketing@gmail.com,prakasitlasree@gmail.com"; // mail B.I.G

                string from = "no-reply@bigintergroup.com";

                string to = mailTo;
                string[] toArray = to.Split(',');

                foreach (var item in toArray)
                {
                    MailMessage msg = new MailMessage(from, item);
                    string[] monthTH = new string[] { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
                    int day = DateTime.Now.Day;
                    int monthIndex = DateTime.Now.Month - 1;
                    int year = DateTime.Now.Year + 543;

                    msg.Subject = "ขอใบเสนอราคา ณ วันที่ " + day + " " + monthTH[monthIndex] + " " + year;

                    StringBuilder detail = new StringBuilder();
                    detail.AppendLine("ชื่อ : " + dataInput.NAME);
                    detail.AppendLine("อีเมล์ : " + dataInput.EMAIL);
                    detail.AppendLine("รายละเอียด : " + dataInput.DESCRIPTION);
                    detail.AppendLine(" ");
                    detail.AppendLine("ส่งจาก : B.I.G Intergroup Website. ");
                    msg.Body = detail.ToString();

                    mailServer.Send(msg);
                }

                result.Status = true;
                result.Message = "ส่งใบเสนอราคาเรียบร้อย ขอบคุณที่ใช้บริการ!!!";

            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = "ไม่สามารถส่งขอใบเสนอราคา" + ex.Message;
            }
             
            return Json(result,JsonRequestBehavior.AllowGet);
        }
    }
}