using LibraryForm.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LibraryForm.Utils
{
    class JsonWriting
    {
        public static async Task WriteAsync(string jsonPath, Rental rental)
        {
            await Task.Run(() =>
            {
                List<Rental> rentals;

                if (File.Exists(jsonPath))
                {
                    string json = File.ReadAllText(jsonPath);
                    rentals = JsonConvert.DeserializeObject<List<Rental>>(json)
                              ?? new List<Rental>();
                }
                else
                {
                    rentals = new List<Rental>();
                }

                rentals.Add(rental);

                string updatedJson = JsonConvert.SerializeObject(
                    rentals, Formatting.Indented);

                File.WriteAllText(jsonPath, updatedJson);
            });
        }

    }
}
