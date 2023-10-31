using System.ComponentModel.DataAnnotations;

namespace CoinConverter.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        

    }
}
