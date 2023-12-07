using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinConverter.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? Username { get; set; } 

        public string? Password { get; set; }

        public string? Email { get; set; } 

        public int ConvertionsNum { get; set; } = 0;

        [ForeignKey("SubscriptionId")]
        public Subscription? Subscription { get; set; }

        public int SubscriptionId { get; set; } = 1;

        public List<Currency>? Currencies { get; set; }
        

    }
}
