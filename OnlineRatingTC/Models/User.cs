using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineRatingTC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        //public string Address { get; set; }
        public string City { get; set; }
        //public string Province { get; set; }
        //public string PostalCode { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}