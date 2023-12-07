using CoinConverter.Entities;
using CoinConverter.Models.DTO;

namespace CoinConverter.Services.Interfaces
{
    public interface IUserServices
    {
        void Create(UserForCreationDto dto);
        User? ValidateUser(AuthRequestDto AuthDto);

    }
}
