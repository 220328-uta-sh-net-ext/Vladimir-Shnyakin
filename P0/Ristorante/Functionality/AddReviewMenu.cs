namespace UI
{
    internal class AddReviewMenu : IMenu
    {
        private ILogic repo = new Operations();
        //IRepository repos = new SqlRepository();
        public void Display()
        {
            Console.WriteLine("ADD REVIEW MENU");
            Console.WriteLine("\nPick a restaurant to review");
            Console.WriteLine("\n---------List of all restaurants-----------\n");
            
            repo.SeeAllRestaurants();
   
            Console.WriteLine("\n--------------End of list------------------\n");
         
            Console.WriteLine("Press <0> to go to Main Menu");
            Console.WriteLine("Press <1> to review a restaurant");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":

                    Console.Write("Please enter your username: ");
                    
                    string username = ValidRating.NotEmpty(Console.ReadLine());
                   
                    Log.Information($"User name entered: {username}");
                    var result = repo.UserExists(username);

                    if (result == true)
                    {
                    start:
                        Console.Write("Please enter the name of a restaurant to review: ");
                        string name = Console.ReadLine();
                        Log.Information($"String, entered by user to search restaurant by name: {name}");
                        name = name.Trim();
                        var results = repo.SearchRestaurant(name);
                        if (results.Count() > 1)
                        {
                            for (int i = 0; i < results.Count(); i++)
                            {
                                ValidRating.OverallRating(results[i]);
                                Console.WriteLine("=================");
                                Console.WriteLine(results[i].ToString());

                            }
                            Console.WriteLine("Please be more specific");
                            goto start;
                        }
                        if (results.Count() == 1)
                        {
                            ValidRating.OverallRating(results[0]);
                            Console.WriteLine(results[0].ToString());
                            Console.WriteLine("Press <1> if you like to review it");
                            Console.WriteLine("Enter <2> to see all reviews for this restaurant");
                            Console.WriteLine("Press <Enter> to go back");
                            string answer = Console.ReadLine();
                            if (answer == "1")
                            {
                                repo.AddReview(results[0].RestaurantName, username);
                            }
                            if (answer == "2")
                            {
                                repo.SeeAllReviews(results[0].RestaurantName);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"No restaurant has {name} in it's name");
                        }
                    }
                    return "AddReview";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddReview";
            }
        }
    }
    internal class ReviewThisRestaurantMenu : IMenu
    {
        private static Review newReview = new Review();
       // private IRepository _repository = new Repository();
        void IMenu.Display()
        {
            Console.WriteLine("Rate THIS RESTAURANT from 1 to 5");
            Console.WriteLine("<6> Price - " + newReview.StarsPrice);
            Console.WriteLine("<5> Service - " + newReview.StarsService);
            Console.WriteLine("<4> Mood - " + newReview.StarsMood);
            Console.WriteLine("<3> Taste - " + newReview.StarsTaste);
            Console.WriteLine("<2> Save");
            Console.WriteLine("<1> Go Back");
            Console.WriteLine("<0> Go to Main Menu");
        }
        string IMenu.UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    return "AddReview";
                case "2":
                    Console.WriteLine("Review saved");
                    return "MainMenu";
                case "3":
                    Console.Write("Please rate taste of food ");
                    newReview.StarsTaste = ValidRating.FiveStars();
                    return "ReviewMenu";
                case "4":
                    Console.Write("Please rate taste mood ");
                    newReview.StarsMood = ValidRating.FiveStars();
                    return "ReviewMenu";
                case "5":
                    Console.Write("Please rate quality of service ");
                    newReview.StarsService = ValidRating.FiveStars();
                    return "ReviewMenu";
                case "6":
                    Console.Write("Please rate price ");
                    newReview.StarsPrice = ValidRating.FiveStars();
                    return "ReviewMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ReviewMenu";
            }
        }
    }
}