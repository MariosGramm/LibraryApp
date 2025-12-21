using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForm.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(int BookId, string Title, string Author)
        {
            this.BookId = BookId;
            this.Title = Title;
            this.Author = Author;
        }

        //Relation
        public List<BookCopy> Copies { get; set; } = new List<BookCopy>(); 
    }
}
