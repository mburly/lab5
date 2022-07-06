using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class BooksOutOnLoan : IClassModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string DateIssued { get; set; }
        public string DueDate { get; set; }
        public string DateReturned { get; set; }
        public int UserId { get; set; }
        public BooksOutOnLoan()
        {

        }
        public BooksOutOnLoan(int id, int bookId, string dateIssued, string dueDate, string dateReturned, int userId)
        {
            Id = id;
            BookId = bookId;
            DateIssued = dateIssued;
            DueDate = dueDate;
            DateReturned = dateReturned;
            UserId = userId;
        }

        public override string ToString()
        {
            return $"Id: {Id}\n" +
                $"Book ID: {BookId}\n" +
                $"Date Issued: {DateIssued}\n" +
                $"Due Date: {DueDate}\n" +
                $"Date Returned: {DateReturned}\n";
        }
    }
}
