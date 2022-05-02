namespace Logic
{
    public class Operations : ILogic
    {
        IRepository repo = new SqlRepository();
        public void SeeAllReviews(string restaurantName)
        {
            var reviews = repo.SeeAllReviews(restaurantName);
            foreach (var review in reviews)
            {
                Console.WriteLine(review.ToString());
                Console.WriteLine("================");
            }
        }
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

            Console.WriteLine("Enter <1> to add a note (no more than 140 characters)");
            string answer = Console.ReadLine();
            if (answer == "1")
                newReview.Note = Console.ReadLine();

               // Console.WriteLine("\nReview saved!\n");
                return repo.AddReview(restaurantName, newReview, userName);
        }
        public void SeeAllRestaurants()
        {
            var restaurants = repo.SeeAllRestaurants();
            foreach (var restaurant in restaurants)
            {
                ValidRating.OverallRating(restaurant);
                Console.WriteLine(restaurant.ToString());
                //Console.WriteLine(restaurant.RestaurantName);
            }
        }
        public string SeeAllRestaurants(int index)
        {
            var restaurants = repo.SeeAllRestaurants();
            return restaurants[index].RestaurantName;
        }
        public List<Restaurant> SearchRestaurant(string name)
        {
            var restaurants = repo.SeeAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(name.ToLower())).ToList();
            return filteredRestaurants;
        }
        public List<Restaurant> SearchRestaurant2(string cuisine)
        {
            var restaurants = repo.SeeAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.Cuisine.ToLower().Contains(cuisine)).ToList();
            return filteredRestaurants;
        }
        public UserAccount AddUser()
        {
            UserAccount newUser = new UserAccount();
            Console.WriteLine("Welcome! Please enter name: ");
            newUser.UserName = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"Please enter password: ");
            ILogic logic = new Operations();
            newUser.Password = logic.GetPassword();
            return repo.AddUser(newUser);
        }
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
            return input.ToString();
        }
        public void SeeAllUsers()
        {
            var users = repo.SeeAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
                //Console.WriteLine(restaurant.RestaurantName);
            }
        }
        public List<UserAccount> SearchUser(string name)
        {
            var users = repo.SeeAllUsers();
            var filteredUsers = users.Where(r => r.UserName.ToLower().Contains(name)).ToList();
            return filteredUsers;
        }
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
            return false;
        }
    }
}