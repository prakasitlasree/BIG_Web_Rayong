using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.WEB.RY.MODEL;
using BIG.WEB.RY.DAL;
 
namespace BIG.WEB.RY.DATASERVICE
{
   public class LogOn_Services
    {
        public List<LOGON> GetAll()
        {
            var result = new List<LOGON>();
            try
            {
                using (var ctx = new BIG_RY_DBEntities())
                { 
                    result = ctx.LOGONs.ToList();
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
