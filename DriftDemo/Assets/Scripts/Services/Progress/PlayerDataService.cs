using Data;
using Infrastructure;
using Zenject;

namespace Services
{
    public class PlayerDataService : IPlayerDataService
    {
        private Currency _currencyInstance;
        private PlayerGarage _playerGarageInstance;

        [Inject]
        public PlayerDataService(IGameFactory gameFactory)
        {
            _currencyInstance = gameFactory.CreateCurrency();
            _playerGarageInstance = gameFactory.CreatePlayerGarage(this);
        }

        public Currency Currency => _currencyInstance;
        public PlayerGarage PlayerGarage => _playerGarageInstance;

    }
}