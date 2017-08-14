using MyBookkeeping.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MyBookkeeping.Models
{
    public class BookkeepingDAO
    {
        private string ConnectionString { get; set; }

        public BookkeepingDAO()
        {
            this.ConnectionString = WebConfigurationManager.ConnectionStrings["DataDB"].ConnectionString;
        }

        public List<BookkeepingListViewModel> GetAllList()
        {
            var result = new List<BookkeepingListViewModel>();

            const string sqlStatement = "Select pDate,BookType,Amount,Remark From Bookkeeping ";

            using (var conn = new SqlConnection(this.ConnectionString))
            using (var command = new SqlCommand(sqlStatement, conn))
            {
                command.CommandType = CommandType.Text;
                command.CommandTimeout = 180;

                if (conn.State != ConnectionState.Open) conn.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {                       
                        BookType bType = (reader["BookType"].ToString() == "1") ? BookType.收入 : BookType.支出;

                        var item = new BookkeepingListViewModel
                        {
                            Date = DateTime.Parse(reader["pDate"].ToString()),
                            Type = bType,
                            Amount = int.Parse(reader["Amount"].ToString()),
                            Remark = reader["Remark"].ToString()
                        };
                        result.Add(item);
                    }
                }
            }
            return result;
        }
    }
}