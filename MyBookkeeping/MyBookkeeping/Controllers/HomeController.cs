using MyBookkeeping.Models;
using MyBookkeeping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MyBookkeeping.Controllers
{
    public class HomeController : Controller
    {
        private BookkeepingDAO dao = new BookkeepingDAO();

        public ActionResult Index(int Page = 1)
        {
            ViewData["CurrentPage"] = Page;
            return View();
        }

        [HttpPost]
        public ActionResult Index(BookkeepingListViewModel PageData)
        {   
            return View(PageData);
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
            /*var history = new List<BookkeepingListViewModel>
            {
                new BookkeepingListViewModel {Type=BookType.支出, Amount=300, Date = new DateTime(2017,1,1), Remark="買書" },
                new BookkeepingListViewModel {Type=BookType.支出, Amount=1600, Date = new DateTime(2017,2,1), Remark="聚餐" },
                new BookkeepingListViewModel {Type=BookType.支出, Amount=800, Date = new DateTime(2017,2,15), Remark="午餐" },
            };*/

            //資料來源改成DB
            var history = dao.GetAllList();

            return View(history);
        }

        public ActionResult ShowHistory1(int Page = 1)
        {
            //使用 PagedList.Mvc 加上分頁
            int pageSize = 10;

            MyBookkeepingContext db = new MyBookkeepingContext();
            int currenPage = Page < 1 ? 1 : Page;
            var BookkeepingList = db.BookkeepingListViewModels.OrderBy(x => x.Date);  /*ToPagedList前必須先OrderBy*/
            var result = BookkeepingList.ToPagedList(currenPage, pageSize);
            ViewData["LineIndex"] = ((Page - 1) * pageSize);
            return View(result);
        }

   }
}