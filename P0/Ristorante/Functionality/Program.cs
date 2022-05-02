Log.Logger = new LoggerConfiguration()
    .WriteTo.File("../../../../Reviews/user.txt").MinimumLevel.Debug().MinimumLevel.Information()
    .CreateLogger();

bool repeat = true;
IMenu menu = new MainMenu();
ILogic repo = new Operations();

while (repeat)
{
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        case "SearchRestaurant":
            menu = new SearchRestaurantMenu();
            break;
        case "AddReview":
            menu = new AddReviewMenu();
            break;
        case "SeeAllReviews":
            Console.WriteLine("--------------Retreiving all reviews---------------");
            //Operations.SeeAllReviews();
            break;
        case "SeeAllRestaurants":
            Console.WriteLine("\n--------------List of all restaurants---------------");
            repo.SeeAllRestaurants();
            Console.WriteLine("------------End of list------------\n");
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "ReviewMenu":
            menu = new ReviewThisRestaurantMenu();
            break;
        case "LoginMenu":
            menu = new LoginMenu();
            break;
        case "AdminMenu":
            menu = new AdminMenu();
            break;
        case "Exit":
            repeat = false;
            break;
        default:
            Console.WriteLine("View does not exist");
            Console.WriteLine("Please press <enter> to continue");
            Console.ReadLine();
            break;
    }
}