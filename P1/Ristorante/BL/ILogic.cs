namespace Logic
{
    /// <summary>
    /// Business logic interface
    /// </summary>
    public interface ILogic
    {
        //Review AddReview(string restaurantName, string userName);
        List<Restaurant> SearchRestaurant(string name);
        List<Restaurant> SearchRestaurantType(string cuisine);
        List<UserAccount> SearchUser(string name);
     
        List<UserAccount> SeeAllUsers();

        List<Review> SeeAllReviews(string restaurantName);

        List<Restaurant> SeeAllRestaurants();
        bool UserMatch(string userName, string password);
        bool UserNameMatch(string userName);
        Restaurant AddRestaurant(Restaurant newRestaurant);
        UserAccount AddUser(UserAccount newUser);
        Review AddReview(Review newReview, string restaurantName, string userName);
    }
}
