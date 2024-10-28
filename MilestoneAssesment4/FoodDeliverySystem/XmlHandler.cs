using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace FoodDeliverySystem
{
    public class XmlHandler
    {
        public static void CreateRestaurantXML(string filePath)
        {
            XElement restaurants = new XElement("restaurants",
                new XElement("restaurant",
                    new XElement("name", "Dominos"),
                    new XElement("address", "Trivandum Street1"),
                    new XElement("rating", "4.2")
                    ),
                new XElement("restaurant",
                    new XElement("name", "KFC"),
                    new XElement("address", "Eranakulam 20 west"),
                    new XElement("rating", "4.5")
                    )
                );
            restaurants.Save( filePath );
            Console.WriteLine("XML file created successfully."+ filePath);
        }

        public static void ParseRestaurantXML(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList nodes = doc.SelectNodes("/restaurants/restaurant");

            foreach (XmlNode node in nodes)
            {
                Console.WriteLine($"Restaurant: {node["name"].InnerText}, Address: {node["address"].InnerText}, Rating: {node["rating"].InnerText}");
            }
        }

    }
}
