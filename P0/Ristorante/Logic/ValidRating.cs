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
            IRepository repo = new SqlRepository();
            repo.SeeAllReviews(toBeRated.RestaurantName).Count();
            List<Review> list = repo.SeeAllReviews(toBeRated.RestaurantName);
            int n = 0;
            double averageTaste = 0;
            double averageMood = 0;
            double averageService = 0;
            double averagePrice = 0;
            if (list.Count > 0)
            {
                foreach (Review r in list)
                {
                    averageTaste += r.StarsTaste;
                    averageMood += r.StarsMood;
                    averageService += r.StarsService;
                    averagePrice += r.StarsPrice;
                    n++;
                }
                toBeRated.OverallRating = Math.Round((averageTaste + averageMood + averageService + averagePrice) / (n * 4), 1);
            }
            if (toBeRated.OverallRating == 0)
                toBeRated.OverallRating = 1;
        }
        public static string NotEmpty(string empty)
        {
            while (String.IsNullOrEmpty(empty))
            {
                Console.WriteLine("This field can not be empty");
                Console.Write("Please enter information: ");
                empty = Convert.ToString(Console.ReadLine());
            }
            return empty.Trim();
        }
    }
}