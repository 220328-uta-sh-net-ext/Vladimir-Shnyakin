namespace Logic
{
    /// <summary>
    /// Buiseness logic itself.
    /// </summary>
    public class Operations : ILogic
    {
        IRepository database = new SqlRepository();

        public List<Review> SeeAllReviews(string restaurantName)
        {
            /*var restaurants = SearchRestaurant(restaurantName);
            List<Review> reviews = new List<Review>();
            foreach (var restaurant in restaurants)
                foreach (var review in restaurant.Reviews)
                    reviews.Add(review);
            return reviews;*/
            return database.GetAllReviews(restaurantName);
        }
        public List<Restaurant> SeeAllRestaurants()
        {
            var restaurants = database.GetAllRestaurants();
            foreach (var restaurant in restaurants)
            {
                restaurant.Reviews = ValidRating.IncludeReviews(restaurant);
                restaurant.OverallRating = ValidRating.OverallRating(restaurant);
            } 
            return restaurants;
        }

        /// <summary>
        /// Asks user to share their experience of a restaurant visited.
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="userName"></param>
        /// <returns>Calls repository method with the same name to store an object
        /// of Review class</returns>
     

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
            foreach (var restaurant in restaurants)
            {
                restaurant.Reviews = ValidRating.IncludeReviews(restaurant);
                restaurant.OverallRating = ValidRating.OverallRating(restaurant);
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
            foreach (var restaurant in restaurants)
            {
                restaurant.Reviews = ValidRating.IncludeReviews(restaurant);
                restaurant.OverallRating = ValidRating.OverallRating(restaurant);
            }
            return filteredRestaurants;
        }
        /// <summary>
        /// Registers user by asking them to input preferred userName
        /// and password
        /// </summary>
        /// <returns>New object of UserAccount class is stored in database</returns>
  
        /// <summary>
        /// Overload of AddUser in case user decided to register not through register but
        /// login menu
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>New object of UserAccount class is stored in database</returns>

   
        /// <summary>
        /// Can be accessed by admin only
        /// </summary>
        public List<UserAccount> SeeAllUsers()
        {
            var users = database.GetAllUsers();
            return users;
        }
        /// <summary>
        /// Find user as admin. UserName must be matched exactly
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List with only one item which is an object of UserAccount class</returns>
        public List<UserAccount> SearchUser(string name)
        {
            var users = database.GetAllUsers();
            var filteredUsers = users.Where(r => r.UserName.ToLower().Contains(name)).ToList();
            return filteredUsers;
        }
        /// <summary>
        /// Matches UserName to the database. If one is found, offers to login or 
        /// register
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserMatch(string userName, string password)
        {
            ILogic logic = new Operations();
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
        }
        public bool UserNameMatch(string userName)
        {
            var users = database.GetAllUsers();

            var foundUser = users.Where(r => r.UserName.Equals(userName)).ToList();

            if (foundUser.Any() == true)
                return true;
            else return false;
        }
        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
          return database.AddRestaurant(newRestaurant);
        }
        public UserAccount AddUser(UserAccount newUser)
        {
            return database.AddUser(newUser);
        }
        public Review AddReview(Review newReview, string restaurantName, string userName)
        {
            return database.AddReview(restaurantName, newReview, userName);
        }
    }
}