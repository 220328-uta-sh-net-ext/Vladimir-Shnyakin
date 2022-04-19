namespace RateApp
{
    public class Review
    {
        public double StarsTaste { get; }
        public double StarsMood { get; }
        public double StarsService { get; }
        public double StarsPrice { get; }
        public bool VisitAgain { get; }
        public double RateTaste()
        {
            {
                List<int> taste = new List<int>();
                Console.WriteLine("How was the food?");
                int tasteInput = Int32.Parse(Console.ReadLine());

                taste.Add(tasteInput);

                double averageTaste = 0;
                for (int i = 0; i < taste.Count; i++)
                    averageTaste = averageTaste + taste[i];

                //System.IO.File.WriteAllLines("tastelog.txt", taste);

                return averageTaste / taste.Count;
            }
        }

        public Review()
        {
            StarsTaste = starsTaste;
            StarsMood = starsMood;
            StarsService = starsService;
            StarsPrice = starsPrice;
        }
        //public Review (int starsTaste, int starsMood, int starsService, int starsPrice)
        //{
        //    StarsTaste = starsTaste;
        //    StarsMood = starsMood;
        //    StarsService = starsService;
        //    StarsPrice = starsPrice;
        //}
        public double starsTaste, starsMood, starsService, starsPrice;
        public double CalculateTotalRating()
        {
            return (starsTaste + starsMood + starsService + starsPrice) / 4;
        }
    }
}