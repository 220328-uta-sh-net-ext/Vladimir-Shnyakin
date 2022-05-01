namespace UI
{
    class MainMenu : IMenu
    {
        ILogic repo = new Operations();
        public void Display()
        {
            Console.WriteLine($"Welcome to RateApp");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("Press <5> to register");
           // Console.WriteLine("Press <4> See all restaurants");
            Console.WriteLine("Press <3> to see all reviews");//move inside SeeAllRestaurants
           // Console.WriteLine("Press <2> Search restaurant");
            Console.WriteLine("Press <1> to review a restaurant");
            Console.WriteLine("Press <0> to exit\n");
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
                    return "SearchRestaurant";
                case "3":
                    return "SeeAllReviews";//move inside SeeAllRestaurants
                case "4":
                    return "SeeAllRestaurants";
                case "5":
                    repo.AddUser();
                    return "AddReview";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
            }
        }
    }
}
