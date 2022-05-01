namespace UI
{
    internal class SearchRestaurantMenu : IMenu
    {
        ILogic repo = new Operations();
        public void Display()
        {
            Console.WriteLine("Please select an option to filter restaurants");
            Console.WriteLine("Press <2> By Cuisine");
            Console.WriteLine("Press <1> By Name");
            Console.WriteLine("Press <0> Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.Write("Please enter the name: ");
                    string name = Console.ReadLine();
                    name = name.Trim();
                    var results = repo.SearchRestaurant(name);
                    if (results.Count() > 0)
                    {
                        for (int i = 0; i < results.Count(); i++)
                        {
                            ValidRating.OverallRating(results[i]);
                            Console.WriteLine("=================");
                            Console.WriteLine(results[i].ToString());
                            if (results.Count() == 1)
                            {
                                Console.WriteLine("Press <1> if you like to review it");
                                string answer = Console.ReadLine();
                             //   if (answer == "1")
                                //    repo.AddReview(results[0].RestaurantName);
                            }
                        }
                        //Console.WriteLine($"Press <1> if you like to review \"{results[0].RestaurantName}\"");
                    }
                    else
                    {
                        Console.WriteLine($"No restaurant has {name} in it's name");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "SearchRestaurant";
                case "2":
                    return "SeerchRestaurant";
                default:
                    Console.WriteLine("Please enter a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "SearchRestaurant";
            }
        }
    }
}
