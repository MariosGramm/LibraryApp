using ClosedXML.Excel;
using LibraryForm.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForm.Utils
{
    class JsonToExcel
    {

        public static void ToExcel(string jsonPath)
        {
            var jsonFile = File.ReadAllText(jsonPath);

            DataTable dt = (DataTable)JsonConvert.DeserializeObject(jsonFile, (typeof(DataTable)));

            using (XLWorkbook wb = new XLWorkbook())
            {

                wb.AddWorksheet(dt, "Loans");

                wb.SaveAs("C:\\Users\\mgrammatopoulos\\Desktop\\LibraryProject\\loans.xlsx");

            }
        }
    }
}
