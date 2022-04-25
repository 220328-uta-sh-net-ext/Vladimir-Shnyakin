namespace Models
{
    public class Review
    {
        //public string RestaurantName { get; set; }
        public double StarsTaste { get; set; }
        public double StarsMood { get; set; }
        public double StarsService { get; set; }
        public double StarsPrice { get; set; }
        //public bool VisitAgain { get; set; }
    
        public double starsTaste, starsMood, starsService, starsPrice;
        public Review()
        {
            StarsTaste = starsTaste;
            StarsMood = starsMood;
            StarsService = starsService;
            StarsPrice = starsPrice;
        }
        //public Review (int starsTaste, int starsMood, int starsService, int starsPrice)
        //{
        //    StarsTaste = starsTaste;
        //    StarsMood = starsMood;
        //    StarsService = starsService;
        //    StarsPrice = starsPrice;
        //}
        public override string ToString()
        {
            return $"Taste: {StarsTaste}\nMood: {StarsMood}\nService: {StarsService}\nPrice: {StarsPrice}\n";
        }
    }
}

