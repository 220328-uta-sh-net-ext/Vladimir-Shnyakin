namespace RateAppDL
{
    public class SqlRepository : IRepository
    {
        private const string connectionStringFilePath = "../../../../Reviews/connection-string.txt";
        private readonly string connectionString;
        public SqlRepository()
        {
            connectionString = File.ReadAllText(connectionStringFilePath);
        }
        public List<Review> SeeAllReviews(string restaurantName)
        {
            string commandString = $"SELECT * FROM Reviews WHERE RestaurantName = '{restaurantName}'";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();
            //using IDataReader reader = command.ExecuteReader();
            var reviews = new List<Review>();
            //DataColumn levelColumn = dataSet.Tables[0].Columns[2];
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                reviews.Add(new Review
                {
                   StarsTaste = (int)row["StarsTaste"],
                   StarsMood = (int)row["StarsMood"],
                   StarsService = (int)row["StarsService"],
                   StarsPrice = (int)row["StarsPrice"],
                   Note = (string)row["Note"],
                   UserName = (string)row["UserName"],
                  // RestaurantName = (string)row["RestaurantName"],

                });
            }
            return reviews;
        }
        public Review AddReview(string restaurantName, Review newReview, string userName)
        {
            string commandString = "INSERT INTO Reviews (StarsTaste, StarsMood, StarsService, StarsPrice, Note, UserName, RestaurantName) " +
                "VALUES (@StarsTaste, @StarsMood, @StarsService, @StarsPrice, @Note, @UserName, @RestaurantName);";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@StarsTaste", newReview.StarsTaste);
                command.Parameters.AddWithValue("@StarsMood", newReview.StarsMood);
                command.Parameters.AddWithValue("@StarsService", newReview.StarsService);
                command.Parameters.AddWithValue("@StarsPrice", newReview.StarsPrice);
                command.Parameters.AddWithValue("@Note", newReview.Note);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@RestaurantName", restaurantName);
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("\nReview saved!\n");
            }
            catch (SqlException ex) 
            {
                Console.WriteLine($"{userName} cannot add another review to this restaurant.\n");
            }
            return newReview;
        }

        public List<Restaurant> SeeAllRestaurants()
        {
            string commandString = "SELECT * FROM Restaurants;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet); // this sends the query. DataAdapter uses a DataReader to read.
            connection.Close();

            // TODO: leaving out the abilities for now
            var restaurants = new List<Restaurant>();
            //DataColumn levelColumn = dataSet.Tables[0].Columns[3];
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                restaurants.Add(new Restaurant
                {
                    RestaurantName = (string)row[0],
                    Cuisine = (string)row["Cuisine"],
                    OverallRating = (double)row["OverallRating"]
                });
            }
            return restaurants;
        }

        public UserAccount AddUser(UserAccount newUser)
        {
            string commandString = "INSERT INTO Users (UserName, Password)" +
                "VALUES (@UserName, @Password);";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            command.Parameters.AddWithValue("@UserName", newUser.UserName);
            command.Parameters.AddWithValue("@Password", newUser.Password);
            connection.Open();
            command.ExecuteNonQuery();

            return newUser;
        }

        public List<UserAccount> SeeAllUsers()
        {
            string commandString = "SELECT * FROM Users;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();

            var users = new List<UserAccount>();
         
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                users.Add(new UserAccount
                {
                    UserName = (string)row[0],
                    Password = (string)row[1]
                });
            }
            return users;
        }
    }
}