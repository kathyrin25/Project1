using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBookkeeping.Models;
using MyBookkeeping.Models.ViewModels;

namespace MyBookkeeping.Controllers
{
    public class BookkeepingListViewModelsController : Controller
    {
        private MyBookkeepingContext db = new MyBookkeepingContext();

        // GET: BookkeepingListViewModels
        public ActionResult Index()
        {
            return View(db.BookkeepingListViewModels.ToList());
        }

        // GET: BookkeepingListViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookkeepingListViewModel bookkeepingListViewModel = db.BookkeepingListViewModels.Find(id);
            if (bookkeepingListViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookkeepingListViewModel);
        }

        // GET: BookkeepingListViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookkeepingListViewModels/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,Date,Remark,Type")] BookkeepingListViewModel bookkeepingListViewModel)
        {
            if (ModelState.IsValid)
            {
                db.BookkeepingListViewModels.Add(bookkeepingListViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookkeepingListViewModel);
        }

        // GET: BookkeepingListViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookkeepingListViewModel bookkeepingListViewModel = db.BookkeepingListViewModels.Find(id);
            if (bookkeepingListViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookkeepingListViewModel);
        }

        // POST: BookkeepingListViewModels/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,Date,Remark,Type")] BookkeepingListViewModel bookkeepingListViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookkeepingListViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookkeepingListViewModel);
        }

        // GET: BookkeepingListViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookkeepingListViewModel bookkeepingListViewModel = db.BookkeepingListViewModels.Find(id);
            if (bookkeepingListViewModel == null)
            {
                return HttpNotFound();
            }
            return View(bookkeepingListViewModel);
        }

        // POST: BookkeepingListViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookkeepingListViewModel bookkeepingListViewModel = db.BookkeepingListViewModels.Find(id);
            db.BookkeepingListViewModels.Remove(bookkeepingListViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
