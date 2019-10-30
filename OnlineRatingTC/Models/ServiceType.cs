using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace OnlineRatingTC.Models
{
    public class ServiceType
    {
        [Key]
        public int ServiceTypeCd { get; set; }
        public string ServiceTypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}