using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinConverter.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; } 

        public string? Password { get; set; }

        public string? Email { get; set; } 

        [ForeignKey("SubscriptionId")]
        public Subscription? subscription { get; set; }

        

    }
}
