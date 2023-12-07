using System.ComponentModel.DataAnnotations;

namespace CoinConverter.Models.DTO
{
    public class CurrencyForCreation_Update
    {
        public string? leyend { get; set; }

        public string? symbol { get; set; }

        public float Ic { get; set; }

        public int UserId { get; set; }
    }
}

