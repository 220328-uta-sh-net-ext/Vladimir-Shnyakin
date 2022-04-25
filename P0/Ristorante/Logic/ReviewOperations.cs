using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RateAppDL;
using Models;

namespace Logic
{
    public class ReviewOperations
    {
        static Repository allreviews = new Repository();
        public static void SeeAllReviews()
        {
            var reviews = allreviews.SeeAllReviews();
            foreach (var review in reviews)
            {
                Console.WriteLine(review.ToString());
            }
        }

        public static void AddReview()
        {
            Repository reviews = new Repository();
            


            Review newReview = new Review();
            //Restaurant restaurant = new Restaurant();
          
         
           
            //IRepository _repository = new Repository();
            

            //newReview.RestaurantName = RestaurantOperations.SeeAllRestaurants(name);

            Console.Write($"Please rate taste of food at \"{RestaurantOperations.SeeAllRestaurants(0)}\" ");
            //newReview.StarsTaste = Convert.ToInt32(Console.ReadLine());
            newReview.StarsTaste = ValidRating.FiveStars();
            Console.Write($"Please rate taste mood at \"{RestaurantOperations.SeeAllRestaurants(0)}\" ");
            newReview.StarsMood = ValidRating.FiveStars();
            Console.Write($"Please rate quality of service at \"{RestaurantOperations.SeeAllRestaurants(0)}\" ");
            newReview.StarsService = ValidRating.FiveStars();
            Console.Write($"Please rate price at \"{RestaurantOperations.SeeAllRestaurants(0)}\" ");
            newReview.StarsPrice = ValidRating.FiveStars();
            
            //reviews.AddRatedRestaurant(restaurant);
            reviews.AddReview(newReview);
            
            //restaurant_repo.AddRatedRestaurant(restaurant);
            //Restaurant rated = ValidRating.AvgRating();
            //rated.RestaurantName = RestaurantOperations.SeeAllRestaurants(name);
            //restaurant_repo.AddRatedRestaurant(rated);
            
            Console.WriteLine("\nReview saved!\n");
        }
    }
    public class RestaurantOperations
    {
        static Repository allrestaurants = new Repository();
        public static void SeeAllRestaurants()
        {
            var restaurants = allrestaurants.SeeAllRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine(restaurant.ToString());
                //Console.WriteLine(restaurant.RestaurantName);
            }
        }
        public static string SeeAllRestaurants(int index)
        {
            var restaurants = allrestaurants.SeeAllRestaurants();
            return restaurants[index].RestaurantName;
        }
        public static Restaurant SeeAllRestaurants2(int index)
        {
            var restaurants = allrestaurants.SeeAllRestaurants();
            return restaurants[index];
        }
    }
}
