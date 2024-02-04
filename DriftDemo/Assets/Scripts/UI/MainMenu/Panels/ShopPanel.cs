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
        private PlayerGarage _playerGarage;

        [Inject]
        public void Construct(IPlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
            _playerGarage = playerDataService.PlayerGarage;
        }

        private void OnEnable()
        {
            InitButton(_car1Button, CarName.Car1);
            InitButton(_car2Button, CarName.Car2);

            _car1Button.onClick.AddListener(OnCar1ButtonPressed);
            _car2Button.onClick.AddListener(OnCar2ButtonPressed);
        }

        private void OnCar1ButtonPressed() => OnPurchaseButtonPressed(_car1Button, CarName.Car1);
        private void OnCar2ButtonPressed() => OnPurchaseButtonPressed(_car2Button, CarName.Car2);

        private void InitButton(Button button, CarName carName) => button.interactable = !_playerDataService.PlayerGarage.IsCarPurchased(carName);

        private void OnPurchaseButtonPressed(Button button, CarName carName)
        {
            if (_playerGarage.BuyCar(carName))
                button.interactable = false;
        }

        private void OnDisable()
        {
            _car1Button.onClick.RemoveListener(OnCar1ButtonPressed);
            _car2Button.onClick.RemoveListener(OnCar2ButtonPressed);
        }
    }
}