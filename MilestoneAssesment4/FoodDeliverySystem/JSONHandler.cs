using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace FoodDeliverySystem
{
    internal class JSONHandler
    {
        public static void CreateReviewJSON(string filePath)
        {
            string jsonContent = @"{
          ""reviews"": [
            { ""restaurant"": ""Pizza Place"", ""review"": ""Great pizza!"", ""rating"": 5 },
            { ""restaurant"": ""Pasta House"", ""review"": ""Too salty."", ""rating"": 2 }
          ]
        }";

            File.WriteAllText(filePath, jsonContent);
            Console.WriteLine("JSON file created successfully.");
        }

        public static void ParseReviewJSON(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            JObject json = JObject.Parse(jsonData);

            foreach (var review in json["reviews"])
            {
                Console.WriteLine($"Review for {review["restaurant"]}: {review["review"]}, Rating: {review["rating"]}");
            }
        }
    }
}
