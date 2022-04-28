namespace Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Cuisine { get; set; }
        public double OverallRating { get; set; }
        public List <Review> Reviews { get; set; }
        public Restaurant()
        {
            RestaurantId++;
            Reviews = new List<Review>()
            {
                new Review()
            };
        }
        public Restaurant(string name)
        {
            RestaurantName = name;
            Reviews = new List<Review>()
            {
                new Review()
            };
        }
        public Restaurant(DataRow row)
        {
            RestaurantName = row["RestaurantName"].ToString() ?? "";
            Cuisine = row["Cuisine"].ToString() ?? "";
        }
        public override string ToString()
        {
            return $"Name: {RestaurantName}\nId: {RestaurantId}\nCuisine: {Cuisine}\nRating: {OverallRating}";
        }
    }
}