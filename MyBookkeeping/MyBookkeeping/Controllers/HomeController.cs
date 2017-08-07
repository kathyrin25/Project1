using MyBookkeeping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookkeeping.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Page - About.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Page - Contact.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult ShowHistory()
        {
            var history = new List<BookkeepingListViewModel>
            {
                new BookkeepingListViewModel {Type=BookType.支出, Amount=300, Date = new DateTime(2017,1,1), Remark="買書" },
                new BookkeepingListViewModel {Type=BookType.支出, Amount=1600, Date = new DateTime(2017,2,1), Remark="聚餐" },
                new BookkeepingListViewModel {Type=BookType.支出, Amount=800, Date = new DateTime(2017,2,15), Remark="午餐" },
            };

            return View(history);
        }
        
    }
}