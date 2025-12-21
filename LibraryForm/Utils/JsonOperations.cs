using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForm.Utils
{
    class JsonOperations
    {
        public static BookLoops Read()
        {
            try
            {
                return JsonConvert.DeserializeObject<BookLoops>(File.ReadAllText("Books.json"));

            }catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching data", ex);
            }
        }

        public static string Write(BookLoops bookList)
        {
            try
            {
                return JsonConvert.SerializeObject(bookList);

            }catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting data", ex);
            }
        }
    }
}
