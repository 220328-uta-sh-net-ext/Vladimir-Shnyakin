using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Restaurant
    {
        [Required]
        public string RestaurantName { get; set; }
        public string Cuisine { get; set; }
        public double OverallRating { get; set; }
        public List <Review> Reviews { get; set; }
        public Restaurant()
        {
            OverallRating = 0;
        }
        public Restaurant(string name)
        {
            OverallRating = 0;
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
            return $"Restaurant: {RestaurantName}\nCuisine: {Cuisine}\nRating: {OverallRating}";
        }
    }
}