using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBookkeeping.Models.ViewModels;

namespace MyBookkeeping.Models
{
    public class MyBookkeepingService
    {
        private readonly MyBookkeepingContext _db;

        public MyBookkeepingService()
        {
            _db = new MyBookkeepingContext();
        }

        public IEnumerable<BookkeepingListViewModel> Lookup()
        {
            return (_db.BookkeepingListViewModels.ToList());
        }

        public BookkeepingListViewModel GetSingle(int id)
        {
            return _db.BookkeepingListViewModels.Find(id);
        }

        public void Add(BookkeepingListViewModel bookkeepingList)
        {
            _db.BookkeepingListViewModels.Add(bookkeepingList);
        }

        public void Edit(BookkeepingListViewModel pageData, BookkeepingListViewModel oldData)
        {
            oldData.Date = pageData.Date;
            oldData.Type = pageData.Type;
            oldData.Amount = pageData.Amount;
            oldData.Remark = pageData.Remark;
        }

        public void Delete(BookkeepingListViewModel data)
        {
            _db.BookkeepingListViewModels.Remove(data);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}