namespace UI
{
    internal class AddReviewMenu : IMenu
    {
        private static Review newReview = new Review();
        private ILogic repo = new Operations();

        public void Display()
        {
            //Console.WriteLine("Rate THIS RESTAURANT from 1 to 5");
            //Console.WriteLine("<5> Price - " + newReview.StarsPrice);
            //Console.WriteLine("<4> Service - " + newReview.StarsService);
            //Console.WriteLine("<3> Mood - " + newReview.StarsMood);
            //Console.WriteLine("<2> Taste - " + newReview.StarsTaste);
            //Console.WriteLine("<1> Save");
            //Console.WriteLine("<0> Go Back");

            Console.WriteLine("Pick a restaurant to review");
            Console.WriteLine("\n--------------List of all restaurants---------------");
            Operations.SeeAllRestaurants();
            Console.WriteLine("------------End of list------------\n");
            Console.WriteLine("Choose a restaurant to review from the above list\n");
            Console.WriteLine("<1> " + Operations.SeeAllRestaurants(0));
            Console.WriteLine("<2> " + Operations.SeeAllRestaurants(1));
            Console.WriteLine("<3> " + Operations.SeeAllRestaurants(2));
            Console.WriteLine("<0> Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    repo.AddReview("Hell's Kitchen");
                    return "AddReview";
                case "2":
                    repo.AddReview(Operations.SeeAllRestaurants(1));
                    return "AddReview";
                case "3":
                    repo.AddReview(Operations.SeeAllRestaurants(2));
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
        private IRepository _repository = new Repository();

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
                    //_repository.AddReview(newReview);
                    Console.WriteLine("Review saved");
                    return "MainMenu";
                case "3":
                    Console.Write("Please rate taste of food ");
                    //newReview.StarsTaste = Convert.ToInt32(Console.ReadLine());
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
