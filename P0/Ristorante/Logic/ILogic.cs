namespace Logic
{
    public interface ILogic
    {
        Review AddReview(string restaurantName, string userName);
        List<Restaurant> SearchRestaurant(string name);
        UserAccount AddUser();
        string GetPassword();
        void SeeAllRestaurants();
        void SeeAllUserss();
        bool UserExists(string userName);
    }
}
