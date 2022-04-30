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
        public List<Review> SeeAllReviews()
        {
            string commandString = "SELECT FirstName FROM SalesLT.Customer"; //CHANGE THAT

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet);
            connection.Close();
            //using IDataReader reader = command.ExecuteReader();
            var reviews = new List<Review>();
            DataColumn levelColumn = dataSet.Tables[0].Columns[2];
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                reviews.Add(new Review
                {
                    //Name = (string)row[0],
                    //Level = (int)row[levelColumn],
                    //Attack = (int)row["Attack"],
                    //Defense = (int)row[4],
                    //Health = (int)row[5]
                });
            }
            return reviews;
        }
        public Review AddReview(string restaurantName, Review newReview)
        {
            string commandString = "INSERT INTO Reviews (StarsTaste, StarsMood, StarsService, StarsPrice, Note, UserName, RestaurantName) " +
                "VALUES (@StarsTaste, @StarsMood, @StarsService, @StarsPrice, @Note, @UserName, @RestaurantName);"; //CHANGE

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            command.Parameters.AddWithValue("@StarsTaste", newReview.StarsTaste);
            command.Parameters.AddWithValue("@StarsMood", newReview.StarsMood);
            command.Parameters.AddWithValue("@StarsService", newReview.StarsService);
            command.Parameters.AddWithValue("@StarsPrice", newReview.StarsPrice);
            command.Parameters.AddWithValue("@Note", "");
            command.Parameters.AddWithValue("@UserName", "Petya");
            command.Parameters.AddWithValue("@RestaurantName", restaurantName);
            connection.Open();
            command.ExecuteNonQuery();

            return newReview;
        }

        public List<Restaurant> SeeAllRestaurants()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}