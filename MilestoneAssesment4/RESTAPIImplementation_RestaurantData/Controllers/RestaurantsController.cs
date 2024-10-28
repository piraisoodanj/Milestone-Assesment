using Microsoft.AspNetCore.Mvc;
using RESTAPIImplementation_RestaurantData.Data;
using RESTAPIImplementation_RestaurantData.Models;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RestaurantsController : Controller
    {
        //Get all Restaurants
        [HttpGet]
        public ActionResult<List<Restaurant>> GetAll()
        {
            return Ok(RestaurantRepository.GetAll());
        }

        //Get Restaurant by name
        [HttpGet("{name}")]
        public ActionResult<Restaurant> GetByName(string name)
        {
            var restaurant = RestaurantRepository.Get(name);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        //Add new Restaurant
        [HttpPost]
        public ActionResult Add(Restaurant restaurant)
        {
            RestaurantRepository.Add(restaurant);
            return CreatedAtAction(nameof(GetAll), new { name = restaurant.Name }, restaurant);
        }

        //Update Restaurant
        [HttpPut("{name}")]
        public ActionResult Update(string name, Restaurant updatedRestaurant)
        {
            var existingRestaurant = RestaurantRepository.Get(name);
            if (existingRestaurant == null)
            {
                return NotFound();
            }

            RestaurantRepository.Update(name, updatedRestaurant);
            return NoContent();
        }

        //Delete Restaurant
        [HttpDelete("{name}")]
        public ActionResult Delete(string name)
        {
            var restaurant = RestaurantRepository.Get(name);
            if (restaurant == null)
            {
                return NotFound();
            }

            RestaurantRepository.Delete(name);
            return NoContent();
        }
    }

}