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
        [SerializeField] private TMP_Dropdown _car2PaintingDropdown;

        private PlayerGarage _playerGarage;
        private CarsMaterialsHolderSO _carsMaterialsHolderSO;
        private IConvertService _convertService;

        [Inject]
        public void Construct(IPlayerDataService playerDataService, CarsMaterialsHolderSO carsMaterialsHolderSO, IConvertService convertService)
        {
            _playerGarage = playerDataService.PlayerGarage;
            _carsMaterialsHolderSO = carsMaterialsHolderSO;
            _convertService = convertService;
        }

        private void OnEnable()
        {
            InitPaintingDropdown(_car1PaintingDropdown, CarName.Car1);
            InitPaintingDropdown(_car2PaintingDropdown, CarName.Car2);

            _car1PaintingDropdown.onValueChanged.AddListener(delegate { OnCar1DropDownValueChanged(_car1PaintingDropdown); });
            _car2PaintingDropdown.onValueChanged.AddListener(delegate { OnCar2DropDownValueChanged(_car2PaintingDropdown); });
        }

        private void OnCar1DropDownValueChanged(TMP_Dropdown change) => _playerGarage.GetPurchasedCar(CarName.Car1).MaterialIndex = change.value;

        private void OnCar2DropDownValueChanged(TMP_Dropdown change) => _playerGarage.GetPurchasedCar(CarName.Car2).MaterialIndex = change.value;

        private void InitPaintingDropdown(TMP_Dropdown dropdown, CarName carName)
        {
            bool enabled = _playerGarage.IsCarPurchased(carName);
            dropdown.gameObject.SetActive(enabled);

            if (enabled) 
            {
                dropdown.ClearOptions();
                List<Material> materials = _carsMaterialsHolderSO.GetCarMaterialsSO(carName).Materials;
                dropdown.AddOptions(_convertService.ConvertMaterialsToString(materials));
                dropdown.value = _playerGarage.GetPurchasedCar(carName).MaterialIndex;
            }
            
        }

        private void OnDisable()
        {
            _car1PaintingDropdown.onValueChanged.RemoveListener(delegate { OnCar1DropDownValueChanged(_car1PaintingDropdown); });
            _car2PaintingDropdown.onValueChanged.RemoveListener(delegate { OnCar2DropDownValueChanged(_car2PaintingDropdown); });
        }
    }
}