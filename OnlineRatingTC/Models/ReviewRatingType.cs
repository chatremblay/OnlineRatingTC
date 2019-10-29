using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRatingTC.Models
{
    public class ReviewRatingType
    {
        [Key]
        public int ReviewRatingTypeCd { get; set; }
        public string ReviewRatingTypeName { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}