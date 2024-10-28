using RESTAPIImplementation_RestaurantData.Models;

namespace RESTAPIImplementation_RestaurantData.Data
{
    public static class RestaurantRepository
    {

        private static List<Restaurant> Restaurants = new List<Restaurant>
    {
        new Restaurant {Id = 100, Name = "Pizza Hut", Address = "123 Main St", Rating = 4.5 },
        new Restaurant {Id = 101, Name = "Grill House", Address = "456 Elm St 5", Rating = 4.2 },
        new Restaurant {Id = 102, Name = "Dominos", Address = "457 Elm St6", Rating = 3.8 },
        new Restaurant {Id = 103,  Name = "Favourite Pizza", Address = "458 Elm St7", Rating = 4.0 },
        new Restaurant {Id = 104,  Name = "AL Baike", Address = "459 Elm St8", Rating = 3.9 },
        new Restaurant {Id = 105,  Name = "Coco Tree", Address = "460 Elm St9", Rating = 4.1 },
        new Restaurant {Id = 106,  Name = "China town", Address = "461 Elm St11", Rating = 5.0 },
        new Restaurant {Id = 107,  Name = "Wow Momos", Address = "462 Elm St12", Rating = 3.5 }
    };

        public static List<Restaurant> GetAll() => Restaurants;

        public static Restaurant Get(string name) => Restaurants.FirstOrDefault(r => r.Name == name);

        public static void Add(Restaurant restaurant) => Restaurants.Add(restaurant);

        public static void Update(string name, Restaurant updatedRestaurant)
        {
            var existing = Get(name);
            if (existing != null)
            {
                existing.Name = updatedRestaurant.Name;
                existing.Address = updatedRestaurant.Address;
                existing.Rating = updatedRestaurant.Rating;
            }
        }

        public static void Delete(string name)
        {
            var restaurant = Get(name);
            if (restaurant != null)
            {
                Restaurants.Remove(restaurant);
            }
        }
    }

}
