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
        Review AddReview(Review newReview);

        List<Review> SeeAllReviews();
    }
}
