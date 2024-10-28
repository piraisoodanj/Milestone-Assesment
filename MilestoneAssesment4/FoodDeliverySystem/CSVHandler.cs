using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliverySystem
{
    internal class CSVHandler
    {
        public static void CreateRestaurantMenuCSV(string filePath)
        {
            string csvContent = "Item,Price\nChicken Dominator Pizza,15\nMargherita Pizza,10\nGarlic Bread,3.99\nCoke,6";
            File.WriteAllText(filePath, csvContent);
            Console.WriteLine("CSV file created successfully.");
        }

        public static void ParseRestaurantMenuCSV(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                if (line != lines[0]) // Skip header
                {
                    var parts = line.Split(',');
                    Console.WriteLine($"Item: {parts[0]}, Price: {parts[1]}");
                }
            }
        }
    }
}
