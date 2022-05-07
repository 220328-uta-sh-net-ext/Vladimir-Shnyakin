namespace Logic
{
    public class ValidRating
    {
        public static bool FiveStars(string stars)
        {
            if (stars == null)
                return false;
            int validStars;
            if (int.TryParse(stars, out validStars))
            {
                if (validStars >= 1 && validStars <= 5)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public static double OverallRating(Restaurant toBeRated)
        {
            IRepository repo = new SqlRepository();
            //repo.GetAllReviews(toBeRated.RestaurantName).Count();
            List<Review> list = repo.GetAllReviews(toBeRated.RestaurantName);
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
            return toBeRated.OverallRating;
        }
        public static List<Review> IncludeReviews(Restaurant withReviews)
        {
            IRepository repo = new SqlRepository();
            List<Review> list = repo.GetAllReviews(withReviews.RestaurantName);
            if (list.Count > 0)
            {
                withReviews.Reviews = new List<Review>();
                    foreach (Review r in list)
                        withReviews.Reviews.Add(r); 
            }
            return withReviews.Reviews;
        }
    }
}