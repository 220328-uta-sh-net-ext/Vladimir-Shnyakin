namespace Logic
{
    /// <summary>
    /// Business logic interface
    /// </summary>
    public interface ILogic
    {
        Review AddReview(string restaurantName, string userName);
        List<Restaurant> SearchRestaurant(string name);
        List<Restaurant> SearchRestaurantType(string cuisine);
        List<UserAccount> SearchUser(string name);
        UserAccount AddUser();
        UserAccount AddUser(string userName);
        string GetPassword();
        void SeeAllRestaurants();
        void SeeAllUsers();
        void SeeAllReviews(string restaurantName);
        bool UserExists(string userName);
    }
}
