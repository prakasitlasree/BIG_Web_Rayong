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
    }
}
