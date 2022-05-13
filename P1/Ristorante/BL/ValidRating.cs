namespace Logic
{
    /*public class ValidRating
    {
        /// <summary>
        /// Checks if rating for newReview is in required range (1 to 5)
        /// </summary>
        /// <param name="stars"></param>
        /// <returns>True if it is, False if it's not</returns>
        public static bool FiveStars(double stars)
        {
            if (stars == null)
                return false;
            if (stars >= 1 && stars <= 5)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Updates overallrating of a restaurant wich is dependent on all reviews for given restaurant.
        /// </summary>
        /// <param name="toBeRated"></param>
        /// <returns>If restaurant has no reviews it's overallraiting is 1</returns>
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
        /// <summary>
        /// Connects restaurant obj with reviews that belong to it
        /// </summary>
        /// <param name="withReviews"></param>
        /// <returns></returns>
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
    }*/
}