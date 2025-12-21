using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryForm.Utils
{
    class ExcelToBookList
    {
        public static List<Book> ΤoBookList(string filepath)
        {
            const int COL_BOOK_ID = 1;
            const int COL_TITLE = 2;
            const int COL_AUTHOR = 3;

            FileInfo file = new FileInfo(filepath);

            var ep = new ExcelPackage(file);
            var ws = ep.Workbook.Worksheets["Sheet1"];

            var result  = new List<Book>();
            for (int row = 2; row <= ws.Dimension.End.Row; row++)
            {
                
                if (ws.Cells[row, COL_BOOK_ID].Value == null ||
                    ws.Cells[row, COL_TITLE].Value == null ||
                    ws.Cells[row, COL_AUTHOR].Value == null)
                {
                    continue;       //skipping line 
                }

                //Parsing bookId
                int bookId = Convert.ToInt32(ws.Cells[row, 1].Value);

                //Parsing title
                string title = ws.Cells[row, 2].Value.ToString();

                //Parsing author 
                string author = ws.Cells[row, 3].Value.ToString();

                Book book = new Book(bookId, title, author);
                result.Add(book);
            }

            return result;
        }

    }
}
