using CoinConverter.Entities;

namespace CoinConverter.Models.DTO
{
    public class CurrencyConvertionRequest
    {
        public int FromCurrencyId { get; set; }
        public int ToCurrencyId { get; set; }
        public float Amount { get; set; }
           
    }
}
