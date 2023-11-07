using System.ComponentModel.DataAnnotations;

namespace CoinConverter.Entities
{
    public class Subscription
    {
        [Key]
        public int SubId { get; set; }

        public string? Name { get; set; } 

        public int Convertions { get; set; }


    }
}
