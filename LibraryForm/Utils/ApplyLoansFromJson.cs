using LibraryForm.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForm.Utils
{
    class ApplyLoansFromJson
    {

        public static void Apply(List<Book> books)
        {
            string jsonPath = "C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\loans.json";

            
            if (!File.Exists(jsonPath))
            {
                return;
            }

            List<Rental> rentals = JsonConvert.DeserializeObject<List<Rental>>
                (File.ReadAllText(jsonPath));

            //If json file is empty 
            if (rentals == null)
            {
                return;
            }

            foreach(Rental rental in rentals)
            {
                //Find book
                var book = books.Find(b => b.BookId == rental.BookId);
                if (book == null) return;

                //Find copy 
                var copy = book.Copies.Find(c => c.CopyId == rental.CopyId);
                if (copy == null) return;

                copy.IsAvailable = false;
                copy.LoanDate = rental.LoanDate;
                copy.ReturnDueDate = rental.ReturnDueDate;
            }
        }
    }
}
