using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using Models;
namespace UI
{
    class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to RateApp");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Press <4> See all restaurants");
            Console.WriteLine("Press <3> See all reviews");
            Console.WriteLine("Press <2> Search reviews");
            Console.WriteLine("Press <1> Review a restaurant");
            Console.WriteLine("Press <0> Exit");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "AddReview";
                case "2":
                    return "SearchPokemon";
                case "3":
                    return "SeeAllReviews";
                case "4":
                    return "SeeAllRestaurants";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
    // private List<Review> allReviews = new List<Review>();
    //public class Restaurant
    //{
    //    string restaurantName = "Hell's Kitchen";
    //    public string Name { get; set; }
    //}
}
