using Data;
using Infrastructure;
using Zenject;

namespace Services
{
    public class CurrencyService : ICurrencyService
    {
        private Currency _currencyInstance;

        [Inject]
        public CurrencyService(IGameFactory gameFactory)
        {
            _currencyInstance = gameFactory.CreateCurrency();
        }

        public Currency Currency => _currencyInstance;
    }
}