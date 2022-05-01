namespace UI
{
    public class LoginMenu : IMenu
    {
        ILogic repo = new Operations();
        void IMenu.Display()
        {
            Console.WriteLine("Welcome to APP!");
            Console.WriteLine("Press <2> to create new Account");
            Console.WriteLine("Press <1> to Log In");
            Console.WriteLine("Press <0> Exit");
        }

        string IMenu.UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    //UserAccount newUser = new UserAccount();

                    //string password = null;
                    Console.Write("Please enter your username: ");
                    string username = Console.ReadLine();
                    username = username.Trim();
                    var result = repo.UserExists(username);

                    if (result == true)
                        return "MainMenu";
                   // else
                       // Console.WriteLine($"{username} is not registered.");
                    //if (repo.UserExists(username) == username)
                    //{
                    //    Console.Write("Plese enter your password: ");
                    //    password = repo.GetPassword();
                    //    if(password == )
                    //}
                    
                    
                    //Console.WriteLine(result.UserName);

                    //if (result.)

                    /*Console.Write("Please enter the name: ");
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
                                if (answer == "1")
                                    repo.AddReview(results[0].RestaurantName);
                            }
                        }
                        Console.WriteLine($"Press <1> if you like to review \"{results[0].RestaurantName}\"");
                    }
                    else
                    {
                        Console.WriteLine($"No restaurant has {name} in it's name");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();*/



                    return "LoginMenu";
                case "2":
                    repo.AddUser();
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "LoginMenu";
            }
        }
    }
}
