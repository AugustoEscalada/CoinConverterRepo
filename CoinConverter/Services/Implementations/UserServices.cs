using CoinConverter.Data;
using CoinConverter.Entities;
using CoinConverter.Models.DTO;
using CoinConverter.Services.Interfaces;

namespace CoinConverter.Services.Implementations
{

    public class UserServices : IUserServices
    {
        private ConverterContext _context;
        public UserServices(ConverterContext context)
        {
            _context = context;
        }

        public User? ValidateUser(AuthRequestDto authRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Username == authRequestBody.Username && p.Password == authRequestBody.Password);
        }

        public void Create(UserForCreationDto dto)
        {
            User newUser = new User()
            {
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }




    }
}
