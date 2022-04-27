namespace Logic
{
    public interface ILogic
    {
        Review AddReview(string restaurantName);
        List<Restaurant> SearchRestaurant(string name);
    }
}
