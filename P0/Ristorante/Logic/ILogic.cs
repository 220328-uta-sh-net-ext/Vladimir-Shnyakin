namespace Logic
{
    public interface ILogic
    {
        Review AddReview(string restaurantName, string userName);
        List<Restaurant> SearchRestaurant(string name);
        List<Restaurant> SearchRestaurant2(string cuisine);
        List<UserAccount> SearchUser(string name);
        UserAccount AddUser();
        string GetPassword();
        void SeeAllRestaurants();
        void SeeAllUsers();
        void SeeAllReviews(string restaurantName);
        bool UserExists(string userName);
    }
}
