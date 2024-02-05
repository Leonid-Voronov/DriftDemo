using UnityEngine;
using TMPro;
using Data;
using Services;
using Zenject;
using Car;
using System.Collections.Generic;

namespace UI.MainMenu
{
    public class GaragePanel : MenuPanel
    {
        [SerializeField] private TMP_Dropdown _car1PaintingDropdown;
        [SerializeField] private TMP_Dropdown _car1TuningDropdown;
        [SerializeField] private TMP_Dropdown _car2PaintingDropdown;

        private PlayerGarage _playerGarage;
        private IDropdownInitializationService _dropdownInitializationService;

        [Inject]
        public void Construct(IPlayerDataService playerDataService, IDropdownInitializationService dropdownInitializationService)
        {
            _playerGarage = playerDataService.PlayerGarage;
            _dropdownInitializationService = dropdownInitializationService;
        }

        private void OnEnable()
        {
            _dropdownInitializationService.InitPaintingDropdown(_car1PaintingDropdown, CarName.Car1);
            _dropdownInitializationService.InitTuningDropdown(_car1TuningDropdown, CarName.Car1);
            _dropdownInitializationService.InitPaintingDropdown(_car2PaintingDropdown, CarName.Car2);

            _car1PaintingDropdown.onValueChanged.AddListener(delegate { OnCar1PaintDropdownValueChanged(_car1PaintingDropdown); });
            _car1TuningDropdown.onValueChanged.AddListener(delegate { OnCar1TuningDropdownValueChanged(_car1TuningDropdown); });
            _car2PaintingDropdown.onValueChanged.AddListener(delegate { OnCar2DropdownValueChanged(_car2PaintingDropdown); });
        }

        private void OnCar1PaintDropdownValueChanged(TMP_Dropdown change) => _playerGarage.GetPurchasedCar(CarName.Car1).MaterialIndex = change.value;

        private void OnCar1TuningDropdownValueChanged(TMP_Dropdown change) => _playerGarage.GetPurchasedCar(CarName.Car1).WithSpoiler = change.value > 0;

        private void OnCar2DropdownValueChanged(TMP_Dropdown change) => _playerGarage.GetPurchasedCar(CarName.Car2).MaterialIndex = change.value;

        private void OnDisable()
        {
            _car1PaintingDropdown.onValueChanged.RemoveListener(delegate { OnCar1PaintDropdownValueChanged(_car1PaintingDropdown); });
            _car1TuningDropdown.onValueChanged.RemoveListener(delegate { OnCar1TuningDropdownValueChanged(_car1TuningDropdown); });
            _car2PaintingDropdown.onValueChanged.RemoveListener(delegate { OnCar2DropdownValueChanged(_car2PaintingDropdown); });
        }
    }
}