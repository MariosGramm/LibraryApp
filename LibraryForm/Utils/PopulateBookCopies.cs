using LibraryForm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForm.Utils
{
    //Populates copies of the books for the first time DataGridView is shown
    public static class PopulateBookCopies
    {
        public static void Populate(List<Book> books)
        {
            foreach (var book in books)
            {
                
                book.Copies.Add(new BookCopy
                {
                    CopyId = 1,
                    BookId = book.BookId,
                    IsAvailable = true
                });

                
                book.Copies.Add(new BookCopy
                {
                    CopyId = 2,
                    BookId = book.BookId,
                    IsAvailable = true
                });

                
                book.Copies.Add(new BookCopy
                {
                    CopyId = 3,
                    BookId = book.BookId,
                    IsAvailable = false,
                    LoanDate = DateTime.Today,
                    ReturnDueDate = DateTime.Today.AddDays(7)
                });
            }
        }
    }
}
