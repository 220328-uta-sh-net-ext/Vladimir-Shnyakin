using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RateAppDL
{
    public interface IRepository
    {
        List<Review> GetAllReviews();
        List<Review> GetAllReviews(string restaurantName);
        Review AddReview(Review newReview);
        List<Restaurant> GetAllRestaurants();
        UserAccount AddUser(UserAccount newUser);
        List<UserAccount> GetAllUsers();
        Restaurant AddRestaurant(Restaurant newRestaurant);
        bool RemoveRestaurant(Restaurant restaurant);
        Task<List<Restaurant>> GetAllRestaurantsAsync();
    }
}
