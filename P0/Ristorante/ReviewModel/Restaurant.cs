using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Restaurant
    {
        public string RestaurantName { get; set; }
        public double AverageTaste { get; set; }
        public double AverageMood { get; set; }
        public double AverageService { get; set; }
        public double AveragePrice { get; set; }
        private List<Review> _reviews;
        public List<Review> Reviews
        {
            get { return _reviews; }
            set { _reviews = value; }
        }

        public Restaurant()
        {
            RestaurantName = "???";
            AverageTaste = 0;//ValidRating.AverageRating();
            AverageMood = 0;
            AverageService = 0;
            AveragePrice = 0;
            _reviews = new List<Review>()
            {
                new Review()
            };
        }
        public override string ToString()
        {
            return $"Name: {RestaurantName}\nTaste: {AverageTaste}\nMood: {AverageMood}\nService: {AverageService}\nPrice: {AveragePrice}";
        }
    }
}
