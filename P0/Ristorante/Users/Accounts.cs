namespace Accounts
{
    public class UserAccount
    {
        //public string Email { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public string userId;
        private string password;
        public UserAccount()
        {
            //Email = email;
            Password = password;
            UserId = userId;
        }
    }
    public class AdminAccount
    {
        private string adminName = "admin", password = "123";
        private string AdminName { get; }
        private string Password { get; set; }
        private AdminAccount(string adminName, string password)
        {
            AdminName = adminName;
            Password = password;
        }
    }
    /*public class Restaurant
    {
        public string RestaurantName { get; }
        public double Stars { get; set; }

        //private List<Review> allReviews = new List<Review>();
        public void newReview(int starsTaste, int starsMood, int starsService, int starsPrice)
        {

        }


        public Restaurant()
        {
            RestaurantName = "Hell's Kitchen";
        }
        public Restaurant(string restaurantName)
        {
            this.RestaurantName=restaurantName;
        }
        public Restaurant(string restaurantName, double stars)
        {
            RestaurantName = restaurantName;
            this.Stars = stars;
        }
    }*/
}