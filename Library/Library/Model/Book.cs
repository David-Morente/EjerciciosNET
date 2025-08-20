using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        
        public Book(string title, string author, string isbn, DateTime publishedDate)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            PublishedDate = publishedDate;
        }

        public  Book()
        {

        }
    }
}
