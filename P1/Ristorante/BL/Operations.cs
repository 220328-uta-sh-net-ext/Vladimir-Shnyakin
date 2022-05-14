namespace Logic
{
    /// <summary>
    /// Buiseness logic itself.
    /// </summary>
    public class Operations : ILogic
    {
        readonly IRepository database;// = new SqlRepository();
        public Operations(IRepository database)
        {
            this.database = database;
        }
        public List<Review> SeeAllReviews(string restaurantName)
        {
            var reviews = database.GetAllReviews();
            var filteredReviews = reviews.Where(r => r.RestaurantName.ToLower().Contains(restaurantName.ToLower())).ToList();

            return filteredReviews;
        }
        /// <summary>
        /// See all restaurants
        /// </summary>
        /// <returns>List of restaurants</returns>
        public List<Restaurant> SeeAllRestaurants()
        {
            var restaurants = database.GetAllRestaurants();
            foreach (var restaurant in restaurants)
            {
               // restaurant.Reviews = IncludeReviews(restaurant);
                restaurant.OverallRating = OverallRating(restaurant);
            } 
            return restaurants;
        }
        /// <summary>
        /// Asynchronous way to get restaurant list
        /// </summary>
        /// <returns>List of restaurants</returns>
        public async Task<List<Restaurant>> SeeAllRestaurantsAsync()
        {
            var restaurants = await database.GetAllRestaurantsAsync();
            foreach (var restaurant in restaurants)
            {
               // restaurant.Reviews = IncludeReviews(restaurant);
                restaurant.OverallRating = OverallRating(restaurant);
            }
            return restaurants;
        }
        /// <summary>
        /// Finds restaurant in a list, taken from repository, by checking if 
        /// restaurant name contains given string
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of class Restaurant objects</returns>
        public List<Restaurant> SearchRestaurant(string name)
        {
            var restaurants = database.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(name.ToLower())).ToList();
            if (filteredRestaurants.Count > 0)
            {
                foreach (var restaurant in filteredRestaurants)
                {
                    //restaurant.Reviews = IncludeReviews(restaurant);
                    restaurant.OverallRating = OverallRating(restaurant);
                }
            }
            return filteredRestaurants;
        }
        /// <summary>
        /// Asynchronous way to call SearchRestaurant
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<List<Restaurant>> SearchRestaurantAsync(string name)
        {
            var restaurants = await database.GetAllRestaurantsAsync();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(name.ToLower())).ToList();
            if (filteredRestaurants.Count > 0)
            {
                foreach (var restaurant in filteredRestaurants)
                {
                    //restaurant.Reviews = IncludeReviews(restaurant);
                    restaurant.OverallRating = OverallRating(restaurant);
                }
            } 
            return filteredRestaurants;
        }
        /// <summary>
        /// Finds restaurant in a list, taken from repository, by checking if 
        /// restaurant type (Cuisine) contains given string
        /// </summary>
        /// <param name="cuisine"></param>
        /// <returns>List of class Restaurant objects</returns>
        public List<Restaurant> SearchRestaurantType(string cuisine)
        {
            var restaurants = database.GetAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.Cuisine.ToLower().Contains(cuisine)).ToList();
            if(filteredRestaurants.Count > 0)
            {
                foreach (var restaurant in filteredRestaurants)
                {
                    //restaurant.Reviews = IncludeReviews(restaurant);
                    restaurant.OverallRating = OverallRating(restaurant);
                }
            }
            
            return filteredRestaurants;
        }
        /// <summary>
        /// Can be accessed by admin only
        /// </summary>
        /// <returns>List of users</returns>
        public List<UserAccount> SeeAllUsers()
        {
            var users = database.GetAllUsers();
            return users;
        }
        /// <summary>
        /// Can be accessed by admin only. Finds user by checking if user name contains given string
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of users</returns>
        public List<UserAccount> SearchUser(string name)
        {
            var users = database.GetAllUsers();
            var filteredUsers = users.Where(r => r.UserName.ToLower().Contains(name.Trim().ToLower())).ToList();
            return filteredUsers;
        }
        /*public bool UserMatch(string userName, string password)
        {
            //ILogic logic = new Operations();
            var users = database.GetAllUsers();

            var foundUser = users.Where(r => r.UserName.Equals(userName)).ToList();

            if (foundUser.Any() == true)
            {
                var foundpassword = users.Where(r => r.Password.Equals(password)).ToList();
                if (foundpassword.Any() == true)
                    return true;
                else
                    return false;
            } 
            else
                return false;
        }*/
       /* public bool UserNameMatch(string userName)
        {
            var users = database.GetAllUsers();

            var foundUser = users.Where(r => r.UserName.Equals(userName)).ToList();

            if (foundUser.Any() == true)
                return true;
            else return false;
        }*/
        public bool AuthenticateUser(UserAccount user)
        {
            List<UserAccount> users = database.GetAllUsers();
            if (users.Exists(a => a.UserName == user.UserName && a.Password == user.Password))
                return true;
            else
                return false;
        }
        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            if (newRestaurant.RestaurantName.Contains('\''))
                throw new ArgumentException("No ' (apostrophe) character allowed in Restaurant name. Use ` (tilda) instead ");
            return database.AddRestaurant(newRestaurant);
        }
        public bool RemoveRestaurant(string restaurantName)
        {
            var restaurants = database.GetAllRestaurants();
            foreach (var item in restaurants)
                if (item.RestaurantName.Equals(restaurantName))
                    if (database.RemoveRestaurant(item) == true)
                        return true;
                
            return false;
        }
        public UserAccount AddUser(UserAccount newUser)
        {
            return database.AddUser(newUser);
        }
        public Review AddReview(Review newReview)
        {
            if (FiveStars(newReview.StarsTaste) == false)
                throw new ArgumentOutOfRangeException("Please rate from 1 to 5");
            if (FiveStars(newReview.StarsMood) == false)
                throw new ArgumentOutOfRangeException("Please rate from 1 to 5");
            if (FiveStars(newReview.StarsService) == false)
                throw new ArgumentOutOfRangeException("Please rate from 1 to 5");
            if (FiveStars(newReview.StarsPrice) == false)
                throw new ArgumentOutOfRangeException("Please rate from 1 to 5");
            
            return database.AddReview(newReview);
        }
        /// <summary>
        /// Checks if rating for newReview is in required range (1 to 5)
        /// </summary>
        /// <param name="stars"></param>
        /// <returns>True if it is, False if it's not</returns>
        public bool FiveStars(double stars)
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
        public double OverallRating(Restaurant toBeRated)
        {
            List<Review> list = database.GetAllReviews(toBeRated.RestaurantName);
            int n = 0;
            double averageTaste = 0;
            double averageMood = 0;
            double averageService = 0;
            double averagePrice = 0;

            toBeRated.Reviews = new List<Review>();
            
            foreach (Review r in list)
            {
                if (r.RestaurantName == toBeRated.RestaurantName)
                {
                    averageTaste += r.StarsTaste;
                    averageMood += r.StarsMood;
                    averageService += r.StarsService;
                    averagePrice += r.StarsPrice;

                    toBeRated.Reviews.Add(r);

                    n++;
                }
            }
            if (n > 0)
                toBeRated.OverallRating = Math.Round((averageTaste + averageMood + averageService + averagePrice) / (n * 4), 1);
            else
                toBeRated.Reviews = null;
            if (toBeRated.OverallRating == 0)
                toBeRated.OverallRating = 1;
            return toBeRated.OverallRating;
        }
       
        /// <summary>
        /// Connects restaurant obj with reviews that belong to it
        /// </summary>
        /// <param name="withReviews"></param>
        /// <returns></returns>
        /*public List<Review> IncludeReviews(Restaurant withReviews)
        {
            //IRepository repo = new SqlRepository();
            List<Review> list = database.GetAllReviews(withReviews.RestaurantName);
            if (list.Count > 0)
            {
                withReviews.Reviews = new List<Review>();
                foreach (Review r in list)
                    withReviews.Reviews.Add(r);
            }
            return withReviews.Reviews;
        }*/
    }
}