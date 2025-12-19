using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;
using System.IO;

namespace LibraryForm.Utils
{
    class ExcelToJson
    {

        public static string Convert()
        {
            using (var stream = File.Open("C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\Books.xlsx", FileMode.Open, FileAccess.Read))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
                var ds = reader.AsDataSet()

            
        }

        public static string Deconvert()
        {

        }
        
        
    }
}
