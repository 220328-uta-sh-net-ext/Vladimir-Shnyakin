namespace Logic
{
    /// <summary>
    /// Buiseness logic itself.
    /// </summary>
    public class Operations : ILogic
    {
        IRepository repo = new SqlRepository();
        /// <summary>
        /// Is used to see all reviews of a restaurant, which is specified by name.
        /// Method is void and prints a list of reviews though overriden ToString()
        /// </summary>
        /// <param name="restaurantName"></param>
        public void SeeAllReviews(string restaurantName)
        {
            var reviews = repo.SeeAllReviews(restaurantName);
            foreach (var review in reviews)
            {
                Console.WriteLine(review.ToString());
                Console.WriteLine("================");
            }
        }
        /// <summary>
        /// Asks user to share their experience of a restaurant visited.
        /// </summary>
        /// <param name="restaurantName"></param>
        /// <param name="userName"></param>
        /// <returns>Calls repository method with the same name to store an object
        /// of Review class</returns>
        public Review AddReview(string restaurantName, string userName)
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
            noteAgain:
            Console.WriteLine("Enter <1> to add a note (no more than 140 characters)");
            string answer = Console.ReadLine();
            
            if (answer == "1")
                newReview.Note = Console.ReadLine();
            if (newReview.Note !=null && newReview.Note.Length > 140)
            {
                Console.WriteLine("Please! No more than 140 characters.");
                goto noteAgain;
            }
            // Console.WriteLine("\nReview saved!\n");
            return repo.AddReview(restaurantName, newReview, userName);
        }
        /// <summary>
        /// Prints list of Restaurant class objects taken from repository.
        /// Before printing adjusts OverallRating of a restaurant
        /// </summary>
        public void SeeAllRestaurants()
        {
            var restaurants = repo.SeeAllRestaurants();
            foreach (var restaurant in restaurants)
            {
                ValidRating.OverallRating(restaurant);
                Console.WriteLine(restaurant.ToString());
            }
        }
        /// <summary>
        /// Finds restaurant in a list, taken from repository, by checking if 
        /// restaurant name contains given string
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List of class Restaurant objects</returns>
        public List<Restaurant> SearchRestaurant(string name)
        {
            var restaurants = repo.SeeAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(name.ToLower())).ToList();
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
            var restaurants = repo.SeeAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.Cuisine.ToLower().Contains(cuisine)).ToList();
            return filteredRestaurants;
        }
        /// <summary>
        /// Registers user by asking them to input preferred userName
        /// and password
        /// </summary>
        /// <returns>New object of UserAccount class is stored in database</returns>
        public UserAccount AddUser()
        {
            UserAccount newUser = new UserAccount();
            Console.WriteLine("Welcome! Please enter name: ");
            newUser.UserName = ValidRating.NotEmpty(Console.ReadLine());
            Console.WriteLine($"Please enter password: ");
            ILogic logic = new Operations();
            newUser.Password = logic.GetPassword();
            return repo.AddUser(newUser);
        }
        /// <summary>
        /// Overload of AddUser in case user decided to register not through register but
        /// login menu
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>New object of UserAccount class is stored in database</returns>
        public UserAccount AddUser(string userName)
        {
            UserAccount newUser = new UserAccount();
            newUser.UserName = userName;
            Console.WriteLine($"Please enter password: ");
            ILogic logic = new Operations();
            newUser.Password = logic.GetPassword();
            Console.WriteLine($"{userName} is registered successfully!");
            return repo.AddUser(newUser);
        }
        /// <summary>
        /// Method from StackOverflow website to make taking password functionality much
        /// better
        /// </summary>
        /// <returns>string</returns>
        public string GetPassword()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                int x = Console.CursorLeft;
                int y = Console.CursorTop;
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input.Remove(input.Length - 1, 1);
                    Console.SetCursorPosition(x - 1, y);
                    Console.Write(" ");
                    Console.SetCursorPosition(x - 1, y);
                }
                else if (key.KeyChar < 32 || key.KeyChar > 126)
                {
                    Trace.WriteLine("Output suppressed: no key char"); //catch non-printable chars, e.g F1, CursorUp and so ...
                }
                else if (key.Key != ConsoleKey.Backspace)
                {
                    input.Append(key.KeyChar);
                    Console.Write("*");
                }
            }
            return ValidRating.NotEmpty(input.ToString());
        }
        /// <summary>
        /// Can be accessed by admin only
        /// </summary>
        public void SeeAllUsers()
        {
            var users = repo.SeeAllUsers();
            foreach (var user in users)
                Console.WriteLine(user.UserName);
        }
        /// <summary>
        /// Find user as admin. UserName must be matched exactly
        /// </summary>
        /// <param name="name"></param>
        /// <returns>List with only one item which is an object of UserAccount class</returns>
        public List<UserAccount> SearchUser(string name)
        {
            var users = repo.SeeAllUsers();
            var filteredUsers = users.Where(r => r.UserName.ToLower().Contains(name)).ToList();
            return filteredUsers;
        }
        /// <summary>
        /// Matches UserName to the database. If one is found, offers to login or 
        /// register
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool UserExists(string userName)
        {
            ILogic logic = new Operations();
            var users = repo.SeeAllUsers();

            var foundUser = users.Where(r => r.UserName.Equals(userName)).ToList();
            //Console.WriteLine(foundUser[0].Password);
            if (foundUser.Any() == true)
            {
                string password = null;
                Console.Write($"{userName} please enter your password: ");
                password = logic.GetPassword();
                //var matchPassword = users.Exists(r => r.Password.Equals(password));
                if (foundUser[0].Password == password)
                    return true;
                else
                    Console.WriteLine("Wrong password!");
                return false;
            }
            else
            {
                Console.WriteLine($"{userName} is not registered.");
                Console.WriteLine($"To register {userName} as new user enter <1>");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    AddUser(userName);
                    return true;
                }
                else
                    return false;
            }
        }
        /// <summary>
        /// Can be accessed from AdminMenu only
        /// </summary>
        /// <returns></returns>
        public Restaurant AddRestaurant()
        {
            Restaurant newRestaurant = new Restaurant();
            Console.Write("New restaurant name will be: ");
            newRestaurant.RestaurantName = ValidRating.NotEmpty(Console.ReadLine());
            Console.Write("New restaurant cuisine type will be: ");
            newRestaurant.Cuisine = ValidRating.NotEmpty(Console.ReadLine());
            return repo.AddRestaurant(newRestaurant);

        }
    }
}