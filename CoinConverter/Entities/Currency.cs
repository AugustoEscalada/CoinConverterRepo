using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoinConverter.Entities
{
    public class Currency
    {
        [Key]

        public int CurrencyId { get; set; }

        [Required]

        public string? leyend { get; set; }

        [Required]
        public string? symbol { get; set; }

        [Required]
        public float Ic { get; set; }

        [ForeignKey("UserId")]

        public User? User { get; set; }

        public int? UserId { get; set; }

    }
}
