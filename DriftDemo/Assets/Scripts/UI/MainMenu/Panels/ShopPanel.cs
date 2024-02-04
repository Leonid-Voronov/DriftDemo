using Data;
using Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.MainMenu
{
    public class ShopPanel : MenuPanel
    {
        [SerializeField] private Button _car1Button;
        [SerializeField] private Button _car2Button;
        private IPlayerDataService _playerDataService;

        [Inject]
        public void Construct(IPlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }

        private void OnEnable()
        {
            InitButton(_car1Button, CarName.Car1);
            InitButton(_car2Button, CarName.Car2);
        }

        private void InitButton(Button button, CarName carName) => button.interactable = !_playerDataService.PlayerGarage.IsCarPurchased(carName);
    }
}