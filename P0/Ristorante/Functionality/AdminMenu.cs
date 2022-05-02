namespace UI
{
    public class AdminMenu : IMenu
    {
        ILogic repo = new Operations();
        void IMenu.Display()
        {
            Console.WriteLine("Welcome! admin");
            Console.WriteLine("<1> see all users!");
            Console.WriteLine("<2> find user by userName");
            Console.WriteLine("<3> add new restaurant");
            Console.WriteLine("<4> Main Menu");
            Console.WriteLine("<0> exit program");
        }
        string IMenu.UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    repo.SeeAllUsers();
                    return "AdminMenu";
                case "2":
                    string userName = Console.ReadLine();
                    foreach (UserAccount user in repo.SearchUser(userName))
                        Console.WriteLine(user.UserName);
                    return "AdminMenu";
                case "3":
                    repo.AddRestaurant();
                    Console.WriteLine("New restaurant added!");
                    return "AdminMenu";
                case "4":
                    return "MainMenu";
                default:
                    return "AdminMenu";
            }
        }
    }
}