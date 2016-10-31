using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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
        public ActionResult List()
        {
            string[] data = new string[] { "湖南永州现形如龙虾花朵 物种已生存上亿年(图)",
                "父亲和妻子患癌该救谁？男子没钱只能救1人 法院频道",
                "网约车向何方？新政让汽车租赁公司遭遇灭顶之灾",
                
            };
            ViewBag.data = data;
            //ViewData["data"] = data;
           // ViewData.Model = data;
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Save(string title, string content)
        {
            ViewBag.Title = title;
            ViewBag.Content = content;

            return View();
        }
    }
}