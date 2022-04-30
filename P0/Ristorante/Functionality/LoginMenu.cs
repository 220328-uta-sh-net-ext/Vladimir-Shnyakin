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
                    return "MainMenu";
                case "2":
                    //repo.AddReview(Operations.SeeAllRestaurants(1));
                    //Console.Write("Please enter your UserName: ");
                    //string userName = Console.ReadLine();
                    //Console.Write("Please enter your password: ");
                    //string password = Console.ReadLine();
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
