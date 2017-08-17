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
        private readonly MyBookkeepingService _BookkeepingSvc;
        private readonly BookkeepingLogService _LogSvc;

        public BookkeepingListViewModelsController()
        {
            _BookkeepingSvc = new MyBookkeepingService();
            _LogSvc = new BookkeepingLogService();
        }        

        // GET: BookkeepingListViewModels
        public ActionResult Index()
        {
            return View(_BookkeepingSvc.Lookup());
        }

        // GET: BookkeepingListViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BookkeepingListViewModel bookkeepingListViewModel = _BookkeepingSvc.GetSingle(id.Value);

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
                _BookkeepingSvc.Add(bookkeepingListViewModel);
                _BookkeepingSvc.Save();

                int recordId = _BookkeepingSvc.GetRecordID();
                _LogSvc.Add(recordId, "Create");
                _LogSvc.Save();          
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
            BookkeepingListViewModel bookkeepingListViewModel = _BookkeepingSvc.GetSingle(id.Value);
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
            var oldData = _BookkeepingSvc.GetSingle(bookkeepingListViewModel.Id);
            if (oldData != null && ModelState.IsValid)
            {
                _BookkeepingSvc.Edit(bookkeepingListViewModel, oldData);
                _BookkeepingSvc.Save();
                _LogSvc.Add(bookkeepingListViewModel.Id, "Edit");
                _LogSvc.Save();
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

            BookkeepingListViewModel bookkeepingListViewModel = _BookkeepingSvc.GetSingle(id.Value);
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
            BookkeepingListViewModel bookkeepingListViewModel = _BookkeepingSvc.GetSingle(id);
            _BookkeepingSvc.Delete(bookkeepingListViewModel);
            _BookkeepingSvc.Save();
            _LogSvc.Add(id, "Delete");
            _LogSvc.Save();
            return RedirectToAction("Index");
        }

        
    }
}
