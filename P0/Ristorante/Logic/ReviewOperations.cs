namespace Logic
{
    public class ReviewOperations : ILogic
    {
        IRepository repo = new Repository();
        public static void SeeAllReviews()
        {
            IRepository repo = new Repository();
            var reviews = repo.SeeAllReviews();
            foreach (var review in reviews)
            {
                Console.WriteLine(review.ToString());
            }
        }
        public Review AddReview(string restaurantName)
        {
            Review newReview = new Review();

            Console.Write($"Please rate taste of food at \"{restaurantName}\" ");
            newReview.StarsTaste = ValidRating.FiveStars();
            Console.Write($"Please rate mood at \"{restaurantName}\" ");
            newReview.StarsMood = ValidRating.FiveStars();
            Console.Write($"Please rate quality of service at \"{restaurantName}\" ");
            newReview.StarsService = ValidRating.FiveStars();
            Console.Write($"Please rate price at \"{restaurantName}\" ");
            newReview.StarsPrice = ValidRating.FiveStars();

            Console.WriteLine("\nReview saved!\n");
            return repo.AddReview(restaurantName, newReview);
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
                ValidRating.OverallRating(restaurant);
                Console.WriteLine(restaurant.ToString());
                //Console.WriteLine(restaurant.RestaurantName);
            }
        }
        public static string SeeAllRestaurants(int index)
        {
            var restaurants = allrestaurants.SeeAllRestaurants();
            return restaurants[index].RestaurantName;
        }
    }
}