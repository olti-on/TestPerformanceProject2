using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestPerformanceProject2.Infrastructure;

namespace TestPerformanceProject2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            int t = 0;
            for (int i = 0; i < 10000000; i++)
            {
                t += i;
            }
            return View();
        }

        [DoNotTrackPerformance]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}