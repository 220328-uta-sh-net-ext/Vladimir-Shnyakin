using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Review
    {
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public double StarsTaste { get; set; }
        [Required]
        public double StarsMood { get; set; }
        [Required]
        public double StarsService { get; set; }
        [Required]
        public double StarsPrice { get; set; }
        public string Note { get; set; }
        public string UserName { get; set; }
        public string userName, restaurantName;
        public double starsTaste, starsMood, starsService, starsPrice;
        
        public Review()
        {
            StarsTaste = starsTaste;
            StarsMood = starsMood;
            StarsService = starsService;
            StarsPrice = starsPrice;
            UserName = userName;
            RestaurantName = restaurantName;
        }
        public Review(string note)
        {
            Note = note;
            StarsTaste = starsTaste;
            StarsMood = starsMood;
            StarsService = starsService;
            StarsPrice = starsPrice;
            UserName = userName;
        }
        public override string ToString()
        {
            return $"Reviewed by {UserName}\nTaste: {StarsTaste}\nMood: {StarsMood}\nService: {StarsService}\nPrice: {StarsPrice}\tNote: {Note}";
        }
    }
}

