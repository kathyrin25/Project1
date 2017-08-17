using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookkeeping.Models
{
    public class BookkeepingLogService
    {
        private readonly MyBookkeepingContext _db;

        public BookkeepingLogService()
        {
            _db = new MyBookkeepingContext();
        }

        public void Add(int RecordId, string Action)
        {
            _db.BookkeepingLogs.Add(new BookkeepingLog
            {
                BookId = RecordId,
                Action = Action,
                UpdateDT = DateTime.Now
            });
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}