using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineRatingTC.Models
{
    public class ReviewRatingType
    {
        [Key]
        public int ReviewRatingTypeCd { get; set; }
        public string ReviewRatingTypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}