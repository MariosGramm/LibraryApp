using System;


namespace LibraryForm.Model
{
    public class BookCopy
    {
        public int CopyId { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? LoanDate { get; set; }
        public DateTime? ReturnDueDate { get; set; }

        //Relation
        public int BookId { get; set; }     
    }
}
