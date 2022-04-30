namespace Logic
{
    public class Operations : ILogic
    {
        IRepository repo = new SqlRepository();
        public static void SeeAllReviews()
        {
           /* //IRepository repo = new Repository();
            var reviews = repo.SeeAllReviews();
            foreach (var review in reviews)
            {
                Console.WriteLine(review.ToString());
            }*/
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
        public List<Restaurant> SearchRestaurant(string name)
        {
            var restaurants = allrestaurants.SeeAllRestaurants();
            var filteredRestaurants = restaurants.Where(r => r.RestaurantName.ToLower().Contains(name)).ToList();
            return filteredRestaurants;
        }
        public UserAccount AddUser()
        {
            UserAccount newUser = new UserAccount();
            Console.WriteLine("Welcome! Please enter your new userId ");
            newUser.UserName = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"Please enter your new password: ");
            ILogic logic = new Operations();
            newUser.Password = logic.GetPassword();
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
    }
}