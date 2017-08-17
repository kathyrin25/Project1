using MyBookkeeping.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBookkeeping.Models
{
    public class BookkeepingLogService
    {
        private readonly IRepository<BookkeepingLog> _logRep;
        private readonly IUnitOfWork _unitOfWork;

        public BookkeepingLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logRep = new Repository<BookkeepingLog>(unitOfWork);
        }

        public void Add(int RecordId, string Action)
        {
            _logRep.Create(new BookkeepingLog
            {
                BookId = RecordId,
                Action = Action,
                UpdateDT = DateTime.Now
            });
        }

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}