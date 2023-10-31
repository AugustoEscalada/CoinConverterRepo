using System.ComponentModel.DataAnnotations;

namespace CoinConverter.Entities
{
    public class Subscription
    {
        [Key]
        public int SubId { get; set; }

        public string name { get; set; } = string.Empty;

        public int convertions { get; set; }


    }
}
