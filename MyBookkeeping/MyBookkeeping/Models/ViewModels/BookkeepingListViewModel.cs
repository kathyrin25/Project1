using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBookkeeping.Models.ViewModels
{
    public class BookkeepingListViewModel
    {
        [Key]
        public int Id { get; set; }  /*EF規定一定要有Key值, 只好變更view model*/

        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "金額")]
        public int Amount { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "日期")]
        public DateTime Date { get; set; }

        [Display(Name = "備註")]
        public string Remark { get; set; }

        [Display(Name = "類別")]
        public BookType Type { get; set; }
        
    }

    public enum BookType
    {
        收入,
        支出
    }
}