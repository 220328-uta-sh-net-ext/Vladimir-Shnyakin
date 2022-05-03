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
       // [Inline("Crabster", "Seafood", Restaurant)]
       // [MemberData ("Happy bread", "Breakfast", Restaurant)]
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

    /*public class ValidRatingTest
    {
        /*
        [Theory]
        [InlineData(1, "Rated 1 stars!\n")]
        [InlineData(6, "Please 1 to 5 only.")]
       // [InlineData("f", "Did you hit wrong button? Please rate from 1 to 5")]
        public void TestValidFiveStars(int input, string expected)
        {
            var actual = ValidRating.FiveStars();
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(5)]
        [InlineData(1)]
        [InlineData(3)]
        public void TestValidRating(int data)
        {
            int output = ValidRating.FiveStars();
            Assert.Equal(data, output);
        }

        [Theory]
        [InlineData("McDuck", )]
        public static void OverallRatingTest(string toBeRated)
        {
            double actual = ValidRating.OverallRating();
        }

    }*/
}