namespace Accounts
{
    /// <summary>
    /// Holds UserName and Password
    /// </summary>
    public class UserAccount
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string userName;
        private string password;
        public UserAccount()
        {
            //Email = email;
            UserName = userName;
            Password = password;
        }
    }
   /* public class AdminAccount
    {
        private string adminName = "admin", password = "123";
        private string AdminName { get; }
        private string Password { get; set; }
        private AdminAccount(string adminName, string password)
        {
            AdminName = adminName;
            Password = password;
        }
    }*/
}