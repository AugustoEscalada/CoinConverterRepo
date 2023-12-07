using CoinConverter.Data;
using CoinConverter.Entities;
using CoinConverter.Models.DTO;
using CoinConverter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace CoinConverter.Services.Implementations
{
    public class CurrencyServices : ICurrencyServices
    {
        private readonly ConverterContext _context;
        public CurrencyServices(ConverterContext converterContext)
        {
            _context = converterContext;
        }

        public void Create(CurrencyForCreation_Update dto, int userId)
        {
            Currency newCurrency = new Currency()
            {
                Ic = dto.Ic,
                leyend = dto.leyend,
                symbol = dto.symbol,
                UserId = userId
            };
            _context.Currency.Add(newCurrency);
            _context.SaveChanges();
        }

        public void Delete(int currencyId)
        {
            _context.Currency.Remove(_context.Currency.Single(u => u.CurrencyId == currencyId));
            _context.SaveChanges();
        }

        public void Update(CurrencyForCreation_Update dto, int currencyId)
        {
            Currency currencyToUpdate = _context.Currency.First(u => u.CurrencyId == currencyId);
            currencyToUpdate.leyend = dto.leyend;
            currencyToUpdate.symbol = dto.symbol;
            currencyToUpdate.Ic = dto.Ic;
            _context.SaveChanges();
        }

        public Currency GetById(int currencyId)
        {
            return _context.Currency.SingleOrDefault(u => u.CurrencyId == currencyId);
        }

        public List<Currency> GetAllCurrencies(int userId) 
        {
            return _context.Currency.Where(c => c.User.UserId == userId).ToList();
        }
        public bool CheckIfCurrencyExists(int currencyId)
        {
            Currency? currency = _context.Currency.FirstOrDefault(u => u.CurrencyId == currencyId);
            return currency != null;
        }


        public float ConvertCurrency(Currency FromCurrency, Currency ToCurrency, float amount, int userId)
        {
            User? user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            user.ConvertionsNum = user.ConvertionsNum + 1;
            long maxConvertions = user.Subscription.Convertions;

            if (user.ConvertionsNum < maxConvertions)
            {
                if (FromCurrency.CurrencyId != ToCurrency.CurrencyId)
                {
                    float totalAmount = amount * FromCurrency.Ic / ToCurrency.Ic;
                    return totalAmount;
                }
                else
                {
                    return amount;
                }
            }
                
            
            return 0;
        }
    }
}
