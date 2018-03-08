using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.WEB.RY.DAL;
using BIG.WEB.RY.MODEL;

namespace BIG.WEB.RY.DATASERVICE
{
    public class PageContent_Services
    {
        public List<PAGE_CONTENT> GetAll()
        {
            var result = new List<PAGE_CONTENT>();
            try
            {
                using (var ctx = new BIG_RY_DBEntities())
                {
                    result = ctx.PAGE_CONTENT.ToList();
                    //result = ctx.PAGE_CONTENT.Include("PAGE_CUSTOMER").ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Result AddPageContent(PAGE_CONTENT dataInput)
        {
            try
            {
                using (var context = new BIG_RY_DBEntities())
                {
                    context.PAGE_CONTENT.Add(dataInput);
                    context.SaveChanges();
                    return new Result() { Message = "Success", Status = true };
                }
            }
            catch (Exception ex)
            {
                return new Result() { Message = ex.Message.ToString(), Status = false };
            }
        }

        public Result EditPageContent(PAGE_CONTENT dataInput)
        {
            try
            {
                using (var context = new BIG_RY_DBEntities())
                {
                    var update = context.PAGE_CONTENT.Where(x => x.AUTO_ID == dataInput.AUTO_ID).FirstOrDefault();
                    if (update != null)
                    {
                        update.HTML_SUB_HEADER1 = dataInput.HTML_SUB_HEADER1;
                        update.HTML_SUB_HEADER2 = dataInput.HTML_SUB_HEADER2;
                        update.UPDATED_DATE = DateTime.Now;
                        update.UPDATED_BY = dataInput.UPDATED_BY;
                        update.HTML_VALUE = dataInput.HTML_VALUE;
                        update.IMAGE_URL = dataInput.IMAGE_URL == null ? update.IMAGE_URL : dataInput.IMAGE_URL;
                        update.STATUS = dataInput.STATUS;
                        update.SEQ = dataInput.SEQ;
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

        public Result DeletePageContent(PAGE_CONTENT dataInput)
        {
            try
            {
                using (var context = new BIG_RY_DBEntities())
                {
                    context.PAGE_CONTENT.Attach(dataInput);
                    context.PAGE_CONTENT.Remove(dataInput);
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
