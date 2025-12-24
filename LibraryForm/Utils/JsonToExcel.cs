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

        public static async Task ToExcelAsync(string jsonPath)
        {
            await Task.Run(() =>
            {
                var jsonFile = File.ReadAllText(jsonPath);

                DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonFile, (typeof(DataTable)));

                using (XLWorkbook wb = new XLWorkbook())
                {

                    wb.AddWorksheet(dt, "Loans");

                    wb.SaveAs("C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\loans.xlsx");

                }

            });
             
        }
    }
}
