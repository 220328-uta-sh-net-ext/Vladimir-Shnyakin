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
        List<Review> GetAllReviews(string restaurantName);
        Review AddReview(string restaurantName, Review newReview, string userName);
        List<Restaurant> GetAllRestaurants();
        UserAccount AddUser(UserAccount newUser);
        List<UserAccount> GetAllUsers();
        Restaurant AddRestaurant(Restaurant newRestaurant);
    }
}
