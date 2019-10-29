using System.Collections.Generic;
using OnlineRatingTC.Models;

namespace OnlineRatingTC.ViewModels
{
    public class ReviewViewModel
    {
        public IEnumerable<Review> Reviews { get; set; }
        public Review Review { set; get; }


        public List<KeyValuePair<int, string>> UsersList;
        public List<KeyValuePair<int, string>> ServicesList;
        public List<KeyValuePair<int, string>> ReviewRatingList;
    }
}