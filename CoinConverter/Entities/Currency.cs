using System.ComponentModel.DataAnnotations;

namespace CoinConverter.Entities
{
    public class Currency
    {
        [Key]

        public int CurrencyId { get; set; } 

        public string? leyend { get; set; }
  
        public string? symbol { get; set; }

        public int Ic { get; set; }
    }
}
