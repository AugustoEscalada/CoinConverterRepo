using CoinConverter.Data;

namespace CoinConverter.Services
{
    public class UserServices
    {
        private readonly ConverterContext _converterContext;

        public UserServices(ConverterContext converterContext)
        {
            _converterContext = converterContext;
        }
    }
}
