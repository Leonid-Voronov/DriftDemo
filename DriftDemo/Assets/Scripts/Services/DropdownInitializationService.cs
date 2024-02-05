using Car;
using Data;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Services
{
    public class DropdownInitializationService : IDropdownInitializationService
    {
        private PlayerGarage _playerGarage;
        private IConvertService _convertService;
        private CarsMaterialsHolderSO _carsMaterialsHolderSO;

        [Inject]
        public DropdownInitializationService(IPlayerDataService playerDataService, IConvertService convertService, CarsMaterialsHolderSO carMaterialsSO)
        {
            _playerGarage = playerDataService.PlayerGarage;
            _convertService = convertService;
            _carsMaterialsHolderSO = carMaterialsSO;
        }

        public void InitPaintingDropdown(TMP_Dropdown dropdown, CarName carName)
        {
            bool enabled = _playerGarage.IsCarPurchased(carName);
            dropdown.gameObject.SetActive(enabled);

            if (enabled)
            {
                dropdown.ClearOptions();
                dropdown.AddOptions(GetMaterialStrings(carName));
                dropdown.value = _playerGarage.GetPurchasedCar(carName).MaterialIndex;
            }
        }

        public void InitTuningDropdown(TMP_Dropdown dropdown, CarName carName)
        {
            bool enabled = _playerGarage.IsCarPurchased(carName);
            dropdown.gameObject.SetActive(enabled);

            if (enabled)
            {
                dropdown.ClearOptions();
                dropdown.AddOptions(GetTuningStrings());
                dropdown.value = _playerGarage.GetPurchasedCar(carName).SpoilerStartIndex;
            }
        }

        private List<string> GetMaterialStrings(CarName carName)
        {
            List<Material> materials = _carsMaterialsHolderSO.GetCarMaterialsSO(carName).Materials;
            return _convertService.ConvertMaterialsToString(materials);
        }

        private List<string> GetTuningStrings() => new List<string>() { "None", "Spoiler1" };
    }
}