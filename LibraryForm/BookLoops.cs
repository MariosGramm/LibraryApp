using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForm
{
    class BookLoops
    {
        public List<Book> Books { get; set; }
    }

    class Book
    {
        public int BookId;
        public string Title = string.Empty;
        public string Author = string.Empty;
    }
}
