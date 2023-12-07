using CoinConverter.Entities;
using CoinConverter.Models.DTO;

namespace CoinConverter.Services.Interfaces
{
    public interface ICurrencyServices
    {
        void Create(CurrencyForCreation_Update dto, int userId  );

        void Delete(int currencyId);

        void Update(CurrencyForCreation_Update dto, int currencyId);

        Currency GetById(int currencyId);

        List<Currency> GetAllCurrencies(int userid);

        bool CheckIfCurrencyExists(int currencyId);

        float ConvertCurrency(Currency fromCurrency, Currency ToCurrency, float amount, int userId);
    }
}
