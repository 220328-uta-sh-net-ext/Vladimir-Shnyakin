/*Console.WriteLine("Welcome! Please enter your userId ");
var userId = Convert.ToString(Console.ReadLine());

Console.WriteLine($"Please enter your password: ");
var password = Convert.ToString(Console.ReadLine());

UserAccount user = new UserAccount();
//UserAccount user = new UserAccount("vasyapupkin@hmail.com", "12345");
//Restaurant restaurant = new Restaurant();


Console.WriteLine($"New user {user.Email} was added!");
Console.WriteLine();
Console.WriteLine($"Please review \"{restaurant.RestaurantName}\" by giving it 1 to 5 stars");
Console.WriteLine();
Review rev = new Review();
//Console.WriteLine("How was the food?");
rev.starsTaste = rev.RateTaste();//Convert.ToInt32(Console.ReadLine());
Console.WriteLine("How was the mood?");
rev.starsMood = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Please rate the service");
rev.starsService = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Price/satisfaction?");
rev.starsPrice = Convert.ToInt32(Console.ReadLine());



Console.WriteLine();

Console.WriteLine($"Thanks! '{restaurant.RestaurantName}' was rated and now its average rating is {rev.CalculateTotalRating()} stars!");

*/


bool repeat = true;
IMenu menu = new LoginMenu();

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
            Operations.SeeAllReviews();
            break;
        case "SeeAllRestaurants":
            Console.WriteLine("\n--------------List of all restaurants---------------");
            Operations.SeeAllRestaurants();
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