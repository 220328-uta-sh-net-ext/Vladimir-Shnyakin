namespace RateAppDL
{
    public class SqlRepository : IRepository
    {
        private const string connectionStringFilePath = "../../../../Reviews/";
        private readonly string connectionString;
        public SqlRepository()
        {
            connectionString = File.ReadAllText(connectionStringFilePath);
        }
        List<Review> IRepository.SeeAllReviews()
        {
            string commandString = "SELECT FirstName FROM SalesLT.Customer"; //CHANGE THAT

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            var reviews = new List<Review>();
            while (reader.Read())
            {
                reviews.Add(new Review { ReviewId = reader.GetString(0) });
            }
            return reviews;
        }
        Review IRepository.AddReview(string restaurantName, Review newReview)
        {
            string commandString = "INSERT INTO SalesLT.Customer (FirstName) VALUES (@name)"; //CHANGE

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            command.Parameters.AddWithValue("@name", newReview.ReviewId);
            connection.Open();
            command.ExecuteNonQuery();

            return newReview;
        }
    }
}