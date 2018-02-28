using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIG.WEB.RY.DAL;


namespace BIG.WEB.RY.MODEL
{
    public class Content
    {
        public List<PAGE_CONTENT> SlideImage { get; set; }
        public List<PAGE_CONTENT> AboutUs { get; set; }
        public List<PAGE_CONTENT> CEO { get; set; }
        public List<PAGE_CONTENT> Policy { get; set; }
        public List<PAGE_CONTENT> Vision { get; set; }
        public List<PAGE_CONTENT> Mission { get; set; }
        public List<PAGE_CONTENT> Branches { get; set; }

        public List<PAGE_CONTENT> Services { get; set; }

        public List<PAGE_CONTENT> Customers { get; set; }

        public List<PAGE_CONTENT> News { get; set; }

        public List<PAGE_CONTENT> Quality { get; set; }
        public List<LOGON> LogOn { get; set; }
        public List<PAGE_CUSTOMER> CustomerList { get; set; }
    }
}
