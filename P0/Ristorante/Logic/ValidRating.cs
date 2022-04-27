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
            int reviewCount = 0;
            double averageTaste = 0;
            double averageMood = 0;
            double averageService = 0;
            double averagePrice = 0;

            for (int i = 0; i < toBeRated.Reviews.Count; i++)
            {
                averageTaste += toBeRated.Reviews[i].StarsTaste;
                averageMood += toBeRated.Reviews[i].StarsMood;
                averageService += toBeRated.Reviews[i].StarsService;
                averagePrice += toBeRated.Reviews[i].StarsPrice;
                reviewCount++;
            }
                
            toBeRated.OverallRating = Math.Round((averageTaste + averageMood + averageService + averagePrice) / (reviewCount*4));
            if (toBeRated.OverallRating == 0)
                toBeRated.OverallRating = 1;
        }
    }
}