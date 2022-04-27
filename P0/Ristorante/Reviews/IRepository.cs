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
        List<Review> SeeAllReviews();
        Review AddReview(string restaurantName, Review newReview);
        List<Restaurant> SeeAllRestaurants();
    }
}
