using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRatingTC.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeCd { get; set; }
        public string ServiceTypeName { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}