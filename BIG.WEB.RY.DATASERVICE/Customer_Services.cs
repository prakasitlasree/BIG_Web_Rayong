using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.WEB.RY.DAL;
using BIG.WEB.RY.MODEL;

namespace BIG.WEB.RY.DATASERVICE
{
   public class Customer_Services
    {
        public List<PAGE_CUSTOMER> GetAll()
        {
            var result = new List<PAGE_CUSTOMER>();
            try
            {
                using (var ctx = new BIG_RY_DBEntities())
                {
                    result = ctx.PAGE_CUSTOMER.ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result AddPageCustomer(PAGE_CUSTOMER dataInput)
        {
            try
            { 
                using (var context = new BIG_RY_DBEntities())
                {
                    context.PAGE_CUSTOMER.Add(dataInput);
                    context.SaveChanges(); 
                    return new Result() { Message = "Success", Status = true }; 
                } 
            }
            catch (Exception ex)
            { 
                return new Result() { Message = ex.Message.ToString(), Status = false };
            } 
        }
         
        public Result EditPageCustomer(PAGE_CUSTOMER dataInput)
        {
            try
            {
                using (var context = new BIG_RY_DBEntities())
                {
                    var update = context.PAGE_CUSTOMER.Where(x => x.AUTO_ID == dataInput.AUTO_ID).FirstOrDefault();
                    if (update != null)
                    {
                        update.PAGE_CONTENT_ID = dataInput.PAGE_CONTENT_ID;
                        update.NAME = dataInput.NAME; 
                        update.LOGO_URL = dataInput.LOGO_URL == null ? update.LOGO_URL : dataInput.LOGO_URL; 
                    }
                    context.SaveChanges(); 
                    return new Result() { Message = "Success", Status = true }; 
                } 
            }
            catch (Exception ex)
            {
                return new Result() { Message = ex.Message.ToString(), Status = false };
            } 
        }

        public Result DeletePageCustomer(PAGE_CUSTOMER dataInput)
        {
            try
            {
                using (var context = new BIG_RY_DBEntities())
                {
                    context.PAGE_CUSTOMER.Attach(dataInput);
                    context.PAGE_CUSTOMER.Remove(dataInput);
                    context.SaveChanges(); 
                    return new Result() { Message = "Success", Status = true }; 
                } 
            }
            catch (Exception ex)
            {
                return new Result() { Message = ex.Message.ToString(), Status = false };
            } 
        }
    }
}
