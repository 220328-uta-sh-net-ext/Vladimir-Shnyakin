using RateAppDL;
using Models;
namespace Logic
{
    public class ValidRating
    {
        public static int FiveStars()
        {
            int stars;
            while (true)
            {
                Console.WriteLine("from 1 to 5");
                string input = Console.ReadLine();

                if (int.TryParse(input, out stars))
                {
                    if (stars >= 1 && stars <= 5)
                    {
                        Console.WriteLine($"Rated {stars} stars!\n");
                        return stars;
                    }
                    else
                        Console.WriteLine("Please 1 to 5 only.");
                }
                else
                    Console.WriteLine("Did you hit wrong button? Please rate from 1 to 5");
            }
        }
        public static Restaurant AvgRating()
        {
            Repository allreviews = new Repository();
            Restaurant rated = new Restaurant();
            rated.RestaurantName = RestaurantOperations.SeeAllRestaurants(0); //HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            var reviews = allreviews.SeeAllReviews();
            var restaurants = allreviews.SeeAllRestaurants();
            int count = 1;
            double averageTaste = 0;
            double averageMood = 0;
            double averageService = 0;
            double averagePrice = 0;
            for (int i = 0; i < restaurants.Count; i++)
            {

                averageTaste += reviews[i].StarsTaste;
                averageMood += reviews[i].StarsMood;
                averageService += reviews[i].StarsService;
                averagePrice += reviews[i].StarsPrice;
                count++;
            }
                
            rated.AverageTaste= Math.Round(averageTaste / count, 1);
            rated.AverageMood= Math.Round(averageMood / count, 1);
            rated.AverageService = Math.Round(averageService / count, 1);
            rated.AveragePrice = Math.Round(averagePrice / count, 1);
            return rated;
        }
        /*public static List<Restaurant> CalculateRating()
        {
            Restaurant avg = new Restaurant();
            Repository allrestaurants = new Repository();
            Repository allreviews = new Repository();

            double averageTaste = 0;
            double averageMood = 0;
            double averageService = 0;
            double averagePrice = 0;
            var reviews = allreviews.SeeAllReviews();
            var restaurants = allrestaurants.SeeAllRestaurants();
            foreach (var review in reviews)
            {
                foreach (var restaurant in restaurants)
                {
                    if (review.RestaurantName == restaurant.RestaurantName)
                    {
                        averageTaste += review.StarsTaste;
                        averageMood += review.StarsMood;
                        averageService += review.StarsService;
                        averagePrice += review.StarsPrice;
                        avg.RestaurantName = review.RestaurantName;
                        restaurants.Add(avg);
                    }
                }
            }
            avg.AverageTaste = Math.Round(averageTaste / reviews.Count(), 1);
            avg.AverageMood = Math.Round(averageMood / reviews.Count(), 1);
            avg.AverageService = Math.Round(averageService / reviews.Count(), 1);
            avg.AveragePrice = Math.Round(averagePrice / reviews.Count(), 1);
            return restaurants;
        }*/
    }
    public class CalculateRating
    {
        
    }
}