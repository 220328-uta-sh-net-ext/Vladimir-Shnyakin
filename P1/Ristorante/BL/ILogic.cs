namespace Logic
{
    /// <summary>
    /// Business logic interface
    /// </summary>
    public interface ILogic
    {
        List<Restaurant> SearchRestaurant(string name);
        Task<List<Restaurant>> SearchRestaurantAsync(string name);
        List<Restaurant> SearchRestaurantType(string cuisine);
        List<UserAccount> SearchUser(string name);
        List<UserAccount> SeeAllUsers();
        List<Review> SeeAllReviews(string restaurantName);
        List<Restaurant> SeeAllRestaurants();
        Task<List<Restaurant>> SeeAllRestaurantsAsync();
        bool AuthenticateUser(UserAccount user);
        Restaurant AddRestaurant(Restaurant newRestaurant);
        bool RemoveRestaurant(string restaurantName);
        UserAccount AddUser(UserAccount newUser);
        Review AddReview(Review newReview);
        bool FiveStars(double stars);
        double OverallRating(Restaurant toBeRated);
        //List<Review> IncludeReviews(Restaurant withReviews);
    }
}
