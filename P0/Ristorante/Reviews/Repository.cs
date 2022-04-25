using System.Text.Json;
using Models;
namespace RateAppDL
{
    public class Repository : IRepository
    {
        private string filePath = "/Users/shado/Desktop/Ristorante/Reviews/Database/";
        private string jsonString;
        public Review AddReview(Review newReview)
        {
            var reviews = SeeAllReviews();
            reviews.Add(newReview);
            var reviewString = JsonSerializer.Serialize<List<Review>>(reviews, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(filePath + "Restaurants.json", reviewString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newReview;
        }
        public List<Review> SeeAllReviews()
        {
            try
            {
                jsonString = File.ReadAllText(filePath + "Restaurants.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!string.IsNullOrEmpty(jsonString))
                return JsonSerializer.Deserialize<List<Review>>(jsonString);
            else
                return null;
        }
        public Restaurant AddRatedRestaurant(Restaurant ratedRestaurant)
        {
            var restaurants = SeeAllRestaurants();
            restaurants.Add(ratedRestaurant);

            var reviewString = JsonSerializer.Serialize<List<Restaurant>>(restaurants, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(filePath + "Restaurants.json", reviewString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ratedRestaurant;
        }
        public List<Restaurant> SeeAllRestaurants()
        {
            try
            {
                jsonString = File.ReadAllText(filePath + "Restaurants.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!string.IsNullOrEmpty(jsonString))
                return JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            else
                return null;
        }
    }
}