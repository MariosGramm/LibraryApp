using ClosedXML.Excel;
using LibraryForm.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryForm.Utils
{
    class JsonToExcel
    {
       
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public static async Task ToExcelAsync(string jsonPath)
        {
            await _semaphore.WaitAsync();   

            try
            {
                await Task.Run(() =>
                {
                    var jsonFile = File.ReadAllText(jsonPath);

                    DataTable dt = (DataTable)JsonConvert.DeserializeObject(
                        jsonFile, typeof(DataTable));

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.AddWorksheet(dt, "Loans");

                        wb.SaveAs(
                            "C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\loans.xlsx");
                    }
                });
            }
            finally
            {
                _semaphore.Release(); 
            }
        }
    }
}
