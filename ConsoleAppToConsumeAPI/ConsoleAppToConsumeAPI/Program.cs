namespace HttpClientSample
{
    public class Review
    {
        public string RestaurantName { get; set; }
        public double StarsTaste { get; set; }
        public double StarsMood { get; set; }
        public double StarsService { get; set; }
        public double StarsPrice { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
    }
        public class Restaurant
    {
        public string RestaurantName { get; set; }
        public string Cuisine { get; set; }
        public double OverallRating { get; set; }
        public List<Review> Reviews { get; set; }
    }

    class Program
    {
        static HttpClient client = new HttpClient();

        static void ShowRestaurant(Restaurant restaurant)
        {
            Console.WriteLine($"\"{restaurant.RestaurantName}\"\nCuisine: " +
                $"{restaurant.Cuisine}\nRaiting: {restaurant.OverallRating}");
        }
        static void ShowReview(Review review)
        {
           // if (review = null)
            Console.WriteLine($"Reviewed by {review.UserName}\nTaste: {review.StarsTaste}\nMood: " +
                $"{review.StarsMood}\nService: {review.StarsService}\nPrice: {review.StarsPrice}\tNote: {review.Note}");
        }
        
        static async Task<List<Restaurant>> GetAllRestaurantsAsync(string path)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List <Restaurant> restaurant = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                restaurant = await response.Content.ReadAsAsync<List<Restaurant>>();
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("It took "+ elapsedMs + "ms to read from DB");
            return restaurant;
        }
        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:7179/");

            try
            {
                var url = "https://localhost:7179/All/Restaurants";

                var restaurants = await GetAllRestaurantsAsync(url);
                Console.WriteLine("\n---------List of all restaurants-----------");
                foreach (var item in restaurants)
                {
                    Console.WriteLine("\n++++++++++++++++++++");
                    ShowRestaurant(item);
                    
                    if (item.Reviews != null)
                    {   
                        foreach (var review in item.Reviews)
                        {
                            Console.WriteLine("--------------------");
                            ShowReview(review);
                            //Console.WriteLine("--------------------");
                        }
                    }
                    else
                        Console.WriteLine("No reviews yet");
                        continue;
                }
                Console.WriteLine("\n--------------End of list------------------\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}