using Logic;
using Models;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Review newReview = new Review();
            newReview.StarsTaste = 6;

            newReview.StarsMood = 3;

            newReview.StarsService = 2;


            newReview.StarsPrice = 1;

            Assert.Equal(6, newReview.StarsTaste);
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
    }
}