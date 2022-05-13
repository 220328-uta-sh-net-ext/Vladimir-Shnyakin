using System;
using System.Collections.Generic;
using System.Linq;
using Accounts;
using Logic;
using Models;
using RateAppDL;
using Xunit;

namespace Tests
{
    public class ModelsTests
    {
        [Fact]
        public void ReviewTest()
        {
            Review newReview = new Review();
            newReview.Note = null;
            newReview.UserName = "Koti4";
            newReview.RestaurantName = "Crusty Crab";
            newReview.StarsTaste = 5;
            newReview.StarsMood = 4;
            newReview.StarsService = 3;
            newReview.StarsPrice = 1;

            Assert.Equal(5, newReview.StarsTaste);
            Assert.Equal(4, newReview.StarsMood);
            Assert.Equal(3, newReview.StarsService);
            Assert.Equal(1, newReview.StarsPrice);
            Assert.Equal("Koti4", newReview.UserName);
            Assert.Equal("Crusty Crab", newReview.RestaurantName);
            Assert.Equal(null, newReview.Note);
        }
        [Fact]
        public void RestaurantTest()
        {
            Restaurant newRestaurant = new Restaurant();
            newRestaurant.RestaurantName = "Happy bread";
            newRestaurant.Cuisine = "Breakfast";

            Assert.Equal("Happy bread", newRestaurant.RestaurantName);
            Assert.Equal("Breakfast", newRestaurant.Cuisine);
        }
        [Fact]
        public void UserAccountTest()
        {
            UserAccount newUser = new UserAccount();
            newUser.UserName = "Demigod";
            newUser.Password = "22Star!";

            Assert.Equal("Demigod", newUser.UserName);
            Assert.Equal("22Star!", newUser.Password);
        }
    }
    public class LogicTest //: IClassFixture<ILogic>
    {
        [Fact]
        public void TestOverallRating()
        {
            
            double expected = 4.5;
            Review review = new Review
            {
                restaurantName = "BBQ",
                Note = "Still remember the taste!",
                starsMood = 4,
                starsPrice = 4,
                starsService = 5,
                starsTaste = 5,
                userName = "vas",
            };
            Restaurant restaurantForTest = new Restaurant
            {
                RestaurantName = "BBQ",
                Cuisine = "American",
                OverallRating = 0,
                Reviews = new List<Review> { review }
            };
            double averageTaste = 0;
            double averageMood = 0;
            double averageService = 0;
            double averagePrice = 0;
            averageTaste += review.starsTaste;
            averageMood += review.starsMood;
            averageService += review.starsService;
            averagePrice += review.starsPrice;
        
            double actual = Math.Round((averageTaste + averageMood + averageService + averagePrice) / (1* 4), 1);
            
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestIncludeReviews()
        {
            Review review = new Review
            {
                RestaurantName = "BBQ",
                Note = "Still remember the taste!",
                StarsMood = 4,
                StarsPrice = 4,
                StarsService = 5,
                StarsTaste = 5,
                UserName = "vas",
            };
         
            Restaurant restaurant = new Restaurant
            {
                RestaurantName = "BBQ",
                Cuisine = "American",
                OverallRating = 0,
                Reviews = new List<Review> { review }
            };

            List<Review> expected = new List<Review>();
            //foreach (Review r in restaurant.Reviews)
                expected.Add(review);

            List<Review> actual = restaurant.Reviews;

            Assert.Equal(expected[0].StarsTaste, actual[0].StarsTaste);
            Assert.Equal(expected[0].UserName, actual[0].UserName);
            Assert.Equal(expected[0].Note, actual[0].Note);
            Assert.Equal(expected[0].StarsMood, actual[0].StarsMood);
            Assert.Equal(expected[0].StarsPrice, actual[0].StarsPrice);
            Assert.Equal(expected[0].StarsService, actual[0].StarsService);
            Assert.Equal(expected[0].RestaurantName, actual[0].RestaurantName);
            //Assert.True(expected.SequenceEqual(actual));
        }
        [Theory]
        [InlineData(-1, false)]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(3.6, true)]
        [InlineData(4, true)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(null, false)]
        public void TestFiveStars(double stars, bool expected)
        {
            bool actual;
            if (stars == null)
                actual = false;
            if (stars >= 1 && stars <= 5)
                actual = true;
            else
                actual= false;

            Assert.Equal(expected, actual);
        }
    }
    public class OperationsTest
    {
        private ILogic _ristoBL;
        [Fact]
        public void TestSeeAllReviews()
        {
            //int expected = 1;
            Review review = new()
            {
                RestaurantName = "BBQ",
                Note = "Still remember the taste!",
                StarsMood = 4,
                StarsPrice = 4,
                StarsService = 5,
                StarsTaste = 5,
                UserName = "vas",
            };
            Restaurant restaurantForTest = new Restaurant
            {
                RestaurantName = "BBQ",
                Cuisine = "American",
                OverallRating = 0,
                Reviews = new List<Review> { review }
            };
            var actual = _ristoBL.SeeAllReviews(restaurantForTest.RestaurantName);
            

            Assert.Equal(review.StarsTaste, actual[0].StarsTaste);
            Assert.Equal(review.StarsMood, actual[0].StarsMood);
            Assert.Equal(review.StarsService, actual[0].StarsService);
            Assert.Equal(review.StarsPrice, actual[0].StarsPrice);
            Assert.Equal(review.UserName, actual[0].UserName);
            Assert.Equal(review.RestaurantName, actual[0].RestaurantName);
            Assert.Equal(review.Note, actual[0].Note);
        }
        [Fact]
        public void TestSeeAllRestaurants()
        {
            int expected = 10;
              
            int actual = _ristoBL.SeeAllRestaurants().Count();

            Assert.Equal(expected, actual);
        }
    }
}