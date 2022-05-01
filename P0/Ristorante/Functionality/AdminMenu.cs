namespace UI
{
    public class AdminMenu : IMenu
    {
        ILogic repo = new Operations();

        void IMenu.Display()
        {
            Console.WriteLine("Welcome! ");
            Console.WriteLine("<1> see all users!");
            Console.WriteLine("<2> find user by userName");
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
                    //Console.WriteLine(repo.SeeAllUsers());
                    return "AdminMenu";
                case "2":
                    string userName = Console.ReadLine();
                    //repo.SearchUser(userName);
                    foreach (UserAccount user in repo.SearchUser(userName))
                        Console.WriteLine(user.UserName);
                    return "AdminMenu";
                default:
                    return "AdminMenu";
            }
        }
    }
}
