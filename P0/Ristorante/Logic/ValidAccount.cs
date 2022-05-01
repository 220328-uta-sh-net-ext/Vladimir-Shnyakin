namespace Logic
{
    public class ValidAccount
    {
        IRepository repo = new SqlRepository();
        /*public static bool IsValidEmail(string email)
        {
            if (!MailAddress.TryCreate(email, out var mailAddress))
                return false;
            return true;
        }*/
        public void AddUser(string userId, string password)
        {
            UserAccount newUser = new UserAccount();
            Console.WriteLine("Welcome! Please enter your new userId ");
            newUser.UserName = Convert.ToString(Console.ReadLine());
            Console.WriteLine($"Please enter your new password: ");
            newUser.Password = Convert.ToString(Console.ReadLine());
            repo.AddUser(newUser);
        }
        /*public List<UserAccount> SeeAllUsers()
        {

        }*/
        public void CheckUser()
        {
            Console.Write("Please enter your UserName: ");
            string userId = Console.ReadLine();

        }
        public bool UserExists(string userName)
        {
            var users = repo.SeeAllUsers();
            foreach (var user in users)
            {
                if (user.userName == userName)
                    return true;
            }
            return false;
        }
    }
}

       