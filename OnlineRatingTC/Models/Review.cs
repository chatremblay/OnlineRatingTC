using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace OnlineRatingTC.Models
{
    public class Review
    {
        [Key]
        public int ReviewsId { set; get; }

        [Required]
        [ForeignKey("UserId")]
        [JsonIgnore]
        public virtual User User { set; get; }
        public int UserId{ set; get; }

        [Required]
        [ForeignKey("ServiceTypeCd")]
        [JsonIgnore]
        public virtual ServiceType ServiceType { set; get; }
        public int ServiceTypeCd { set; get; }

        [Required]
        [ForeignKey("ReviewRatingTypeCd")]
        [JsonIgnore]
        public virtual ReviewRatingType ReviewRatingType { get; set; }
        public int ReviewRatingTypeCd { set; get; }

        [Required]
        [StringLength(250, ErrorMessage = "The Comments have a maximum of 250 char")]
        public string Comments { set; get; }
    }
}