using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace FoodDeliverySystem
{
    internal class ExcelHandler
    {
        public static void CreateRestaurantExcel(string filePath)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Restaurants");
            worksheet.Cell(1, 1).Value = "Name";
            worksheet.Cell(1, 2).Value = "Address";
            worksheet.Cell(1, 3).Value = "Rating";
            worksheet.Cell(2, 1).Value = "Pasta House";
            worksheet.Cell(2, 2).Value = "456 Elm St";
            worksheet.Cell(2, 3).Value = 4.2;

            workbook.SaveAs(filePath);
            Console.WriteLine("Excel file created successfully.");
        }

        public static void ReadRestaurantExcel(string filePath)
        {
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheets.Worksheet(1);

            foreach (var row in worksheet.RowsUsed())
            {
                if (row.RowNumber() > 1) // Skip header
                {
                    Console.WriteLine($"Restaurant: {row.Cell(1).GetValue<string>()}, Address: {row.Cell(2).GetValue<string>()}, Rating: {row.Cell(3).GetValue<double>()}");
                }
            }
        }
    }
}
