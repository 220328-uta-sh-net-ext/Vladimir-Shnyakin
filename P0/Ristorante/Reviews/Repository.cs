namespace RateAppDL
{
    public class Repository : IRepository
    {
        private string filePath = "../../../../Reviews/Database/";
        private string jsonString;
        public Review AddReview(string restaurantName, Review newReview, string userName)
        {
            var restaurants = SeeAllRestaurants();

            foreach (var restaurant in restaurants)
            {
                if (restaurant.RestaurantName == restaurantName)
                {
                    restaurant.Reviews.Add(newReview);
                    break;
                }
            }
            var reviewString = JsonSerializer.Serialize<List<Restaurant>>(restaurants, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(filePath + "Restaurants.json", reviewString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newReview;
        }
        public List<Review> SeeAllReviews(string restaurantName)
        {
            try
            {
                jsonString = File.ReadAllText(filePath + "Restaurants.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!string.IsNullOrEmpty(jsonString))
                return JsonSerializer.Deserialize<List<Review>>(jsonString);
            else
                return null;
        }
        public Restaurant AddRatedRestaurant(Restaurant ratedRestaurant)
        {
            var restaurants = SeeAllRestaurants();
            restaurants.Add(ratedRestaurant);

            var reviewString = JsonSerializer.Serialize<List<Restaurant>>(restaurants, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(filePath + "Restaurants.json", reviewString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ratedRestaurant;
        }
        public List<Restaurant> SeeAllRestaurants()
        {
            try
            {
                jsonString = File.ReadAllText(filePath + "Restaurants.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!string.IsNullOrEmpty(jsonString))
                return JsonSerializer.Deserialize<List<Restaurant>>(jsonString);
            else
                return null;
        }
        public List<UserAccount> SeeAllUsers()
        {
            try
            {
                jsonString = File.ReadAllText(filePath + "Restaurants.json");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (!string.IsNullOrEmpty(jsonString))
                return JsonSerializer.Deserialize<List<UserAccount>>(jsonString);
            else
                return null;
        }
        public UserAccount AddUser(UserAccount newUser)
        {
            var users = SeeAllUsers();
            users.Add(newUser);

            var reviewString = JsonSerializer.Serialize<List<UserAccount>>(users, new JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(filePath + "Restaurants.json", reviewString);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Please check the path, " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Please check the file name, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return newUser;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            throw new NotImplementedException();
        }
    }
}