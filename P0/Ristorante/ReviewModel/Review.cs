namespace Models
{
    public class Review
    {
        public double StarsTaste { get; set; }
        public double StarsMood { get; set; }
        public double StarsService { get; set; }
        public double StarsPrice { get; set; }
        public string Note { get; set; }
        //public string RestaurantName { get; set; } //to connect to the restaurant
        //public string ReviewId { get; set; } // to log in database
        //public bool VisitAgain { get; set; }
        public string UserName { get; set; }
        public string RestaurantName { get; set; }
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
        //public Review (int starsTaste, int starsMood, int starsService, int starsPrice)
        //{
        //    StarsTaste = starsTaste;
        //    StarsMood = starsMood;
        //    StarsService = starsService;
        //    StarsPrice = starsPrice;
        //}
     /*   public override string ToString()
        {
            return $"Taste: {StarsTaste}\nMood: {StarsMood}\nService: {StarsService}\nPrice: {StarsPrice}\tNote: {Note}";
        }*/
    }
}

