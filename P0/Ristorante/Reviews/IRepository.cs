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
        List<Review> SeeAllReviews(string restaurantName);
        Review AddReview(string restaurantName, Review newReview, string UserName);
        List<Restaurant> SeeAllRestaurants();
        UserAccount AddUser(UserAccount newUser);
        List<UserAccount> SeeAllUsers();
        Restaurant AddRestaurant(Restaurant newRestaurant);
    }
}
