using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBookkeeping.Models.ViewModels;
using MyBookkeeping.Repositories;

namespace MyBookkeeping.Models
{
    public class MyBookkeepingService
    {
        private readonly IRepository<BookkeepingListViewModel> _BookkeepingListRep;
        private readonly IUnitOfWork _unitOfWork;

        public MyBookkeepingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _BookkeepingListRep = new Repository<BookkeepingListViewModel>(unitOfWork);
        }

        public IEnumerable<BookkeepingListViewModel> Lookup()
        {
            return _BookkeepingListRep.LookupAll();
        }

        public BookkeepingListViewModel GetSingle(int RecordId)
        {
            return _BookkeepingListRep.GetSingle(d => d.Id == RecordId);
        }

        public void Add(BookkeepingListViewModel bookkeepingList)
        {
            _BookkeepingListRep.Create(bookkeepingList);
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
            _BookkeepingListRep.Remove(data);
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        public int GetRecordID()
        {
            //因為table 設計不好, id 是自動增加, 只好以這種方式取得新增資料的id, 應改成用guid
            return _BookkeepingListRep.LookupAll().OrderByDescending(x => x.Id).FirstOrDefault().Id;
        }
    }
}