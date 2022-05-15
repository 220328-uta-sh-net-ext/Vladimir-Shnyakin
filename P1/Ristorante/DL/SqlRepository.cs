namespace RateAppDL
{
    public class SqlRepository : IRepository
    {
        //private const string connectionStringFilePath = "../DL/connection-string.txt";
        private readonly string connectionString;
        public SqlRepository(string connectionString)
        {
         this.connectionString = connectionString;
        }
        public List<Review> GetAllReviews()
        {
            string commandString = $"SELECT * FROM Reviews;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            Log.Information($"SQL command \"{commandString}\" was used");
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();
            var reviews = new List<Review>();
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
                    RestaurantName = (string)row["RestaurantName"]
                });
            }
            return reviews;
        }
        public List<Review> GetAllReviews(string restaurantName)
        {
            string commandString = "SELECT * FROM Reviews WHERE RestaurantName = @RestaurantName;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            Log.Information($"SQL command \"{commandString}\" was used");
            command.Parameters.AddWithValue("@RestaurantName", restaurantName);
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();
            var reviews = new List<Review>();
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
                   RestaurantName = (string)row["RestaurantName"]
                });
            }
            return reviews;
        }
        public Review AddReview(Review newReview)
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
                command.Parameters.AddWithValue("@UserName", newReview.UserName);
                command.Parameters.AddWithValue("@RestaurantName", newReview.RestaurantName);
                Log.Information($"SQL command \"{commandString}\" was used");
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) 
            {
                throw;
            }
            return newReview;
        }
        public Review ChangeReview(Review newReview)
        {
            string commandString = "UPDATE Reviews SET StarsTaste = @StarsTaste, StarsMood = @StarsMood," +
                " StarsService = @StarsService, StarsPrice = @StarsPrice, Note = @Note " +
                "WHERE UserName = @UserName AND RestaurantName = @RestaurantName;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@StarsTaste", newReview.StarsTaste);
                command.Parameters.AddWithValue("@StarsMood", newReview.StarsMood);
                command.Parameters.AddWithValue("@StarsService", newReview.StarsService);
                command.Parameters.AddWithValue("@StarsPrice", newReview.StarsPrice);
                command.Parameters.AddWithValue("@Note", newReview.Note);
                command.Parameters.AddWithValue("@UserName", newReview.UserName);
                command.Parameters.AddWithValue("@RestaurantName", newReview.RestaurantName);
                Log.Information($"SQL command \"{commandString}\" was used");
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            return newReview;
        }
        public List<Restaurant> GetAllRestaurants()
        {
            string commandString = "SELECT * FROM Restaurants;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            Log.Information($"SQL command \"{commandString}\" was used");
            connection.Open();
            adapter.Fill(dataSet); // this sends the query. DataAdapter uses a DataReader to read.
            connection.Close();

            var restaurants = new List<Restaurant>();
            
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
        public async Task<List<Restaurant>> GetAllRestaurantsAsync()
        {
            string commandString = "SELECT * FROM Restaurants;";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            Log.Information($"SQL command \"{commandString}\" was used");
            try
            {
                await connection.OpenAsync();
                adapter.Fill(dataSet);
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            var restaurants = new List<Restaurant>();

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
            Log.Information($"SQL command \"{commandString}\" was used");
            try
            {
                command.Parameters.AddWithValue("@UserName", newUser.UserName);
                command.Parameters.AddWithValue("@Password", newUser.Password);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            return newUser;
        }
        public UserAccount ChangeUser(UserAccount newUser, string userId)
        {
            string commandString = "UPDATE Users SET UserName = @newUserName, Password = @newPassword " +
                "WHERE UserName = @UserName;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            Log.Information($"SQL command \"{commandString}\" was used");
            try
            {
                command.Parameters.AddWithValue("@UserName", userId);
                command.Parameters.AddWithValue("@newUserName", newUser.UserName);
                command.Parameters.AddWithValue("@newPassword", newUser.Password);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            return newUser;
        }
        public List<UserAccount> GetAllUsers()
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
        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            string commandString = "INSERT INTO Restaurants (RestaurantName, Cuisine)" +
                "VALUES (@RestaurantName, @Cuisine);";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@RestaurantName", newRestaurant.RestaurantName);
                command.Parameters.AddWithValue("@Cuisine", newRestaurant.Cuisine);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw;
            }
            return newRestaurant;
        }
        public bool RemoveRestaurant(Restaurant restaurant)
        {
            string commandString = "DELETE FROM Restaurants WHERE RestaurantName = @RestaurantName;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
               command.Parameters.AddWithValue("@RestaurantName", restaurant.RestaurantName);
               connection.Open();
               command.ExecuteNonQuery();
               return true;
            }
            catch(SqlException ex)
            {
                throw;
            }
        }
        public bool RemoveUser(UserAccount user)
        {
            string commandString = $"DELETE FROM Users WHERE UserName = @UserName;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@UserName", user.UserName);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
        public bool RemoveReview(Review review)
        {
            string commandString = "DELETE FROM Reviews WHERE UserName = @UserName AND RestaurantName = @RestaurantName;";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@UserName", review.UserName);
                command.Parameters.AddWithValue("@RestaurantName", review.RestaurantName);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}