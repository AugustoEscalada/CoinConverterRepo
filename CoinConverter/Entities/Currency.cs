using System.ComponentModel.DataAnnotations;

namespace CoinConverter.Entities
{
    public class Currency
    {
        [Key]

        public int CurrencyId { get; set; } 

        public int Ic { get; set; }
    }
}
