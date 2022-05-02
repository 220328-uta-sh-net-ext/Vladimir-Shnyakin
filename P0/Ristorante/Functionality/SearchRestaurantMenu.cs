namespace UI
{
    /// <summary>
    /// Provides two options to search: by Name and by Cuisine
    /// </summary>
    internal class SearchRestaurantMenu : IMenu
    {
        ILogic repo = new Operations();
        public void Display()
        {
            Console.WriteLine("\nSEARCH RESTAURANT MENU\n");
            Console.WriteLine("Please select an option to filter restaurants\n");
            Console.WriteLine("Press <1> By Name");
            Console.WriteLine("Press <2> By Cuisine");
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
                    string name = Console.ReadLine().Trim();
                    var results = repo.SearchRestaurant(name);
                    if (results.Count() > 0)
                    {
                        for (int i = 0; i < results.Count(); i++)
                        {
                            ValidRating.OverallRating(results[i]);
                            Console.WriteLine("=================");
                            Console.WriteLine(results[i].ToString());
                            repo.SeeAllReviews(results[i].RestaurantName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No restaurant has {name} in it's name");
                    }
                    return "SearchRestaurant";
                case "2":
                    Console.Write("Please enter the cuisine type: ");
                    string cuisine = Console.ReadLine().Trim();
                    var cuisines = repo.SearchRestaurantType(cuisine);
                    if (cuisines.Count() > 0)
                    {
                        for (int i = 0; i < cuisines.Count(); i++)
                        {
                            ValidRating.OverallRating(cuisines[i]);
                            Console.WriteLine("=================");
                            Console.WriteLine(cuisines[i].ToString());
                            repo.SeeAllReviews(cuisines[i].RestaurantName);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No restaurant has {cuisine} type");
                    }
                    return "SearchRestaurant";
                default:
                    Console.WriteLine("Please enter a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "SearchRestaurant";
            }
        }
    }
}