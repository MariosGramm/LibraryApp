using System;

namespace LibraryForm.Model
{
    class Loan
    {
        public int BookId { get; set; }
        public int CopyId { get; set; }
        public string Title { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDueDate { get; set; }
        public string Borrower { get; set; }
    }
}
