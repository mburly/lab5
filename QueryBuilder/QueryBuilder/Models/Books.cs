using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryBuilder.Models
{
    public class Books : IClassModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public string DateOfPublication { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public Books()
        {

        }
        public Books(int id, string title, string isbn, string dateOfPublication, int categoryId, int authorId)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            DateOfPublication = dateOfPublication;
            CategoryId = categoryId;
            AuthorId = authorId;
        }
    }
}
