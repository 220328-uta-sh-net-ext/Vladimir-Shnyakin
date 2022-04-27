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
        public static void OverallRating(Restaurant toBeRated)
        {
            Repository allreviews = new Repository();
            toBeRated.RestaurantName = RestaurantOperations.SeeAllRestaurants(0); //HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
                
            toBeRated.OverallRating = Math.Round((averageTaste + averageMood + averageService + averagePrice) / count, 1);
        }
    }
}