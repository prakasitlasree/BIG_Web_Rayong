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
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
