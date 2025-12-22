using LibraryForm.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace LibraryForm.Utils
{
    class JsonOperations
    {
        public static List<Rental> Read(string filepath)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Rental>>(File.ReadAllText(filepath));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error fetching data", ex);
            }
        }

        public static string Write(Rental rental)
        {
            try
            {
                return JsonConvert.SerializeObject(rental);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting data", ex);
            }
        }
    }
}
