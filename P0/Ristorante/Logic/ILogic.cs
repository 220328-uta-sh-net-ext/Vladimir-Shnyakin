namespace Logic
{
    public interface ILogic
    {
        Review AddReview(string restaurantName, string userName);
        List<Restaurant> SearchRestaurant(string name);
        List<UserAccount> SearchUser(string name);
        UserAccount AddUser();
        string GetPassword();
        void SeeAllRestaurants();
        void SeeAllUsers();
        bool UserExists(string userName);
    }
}
