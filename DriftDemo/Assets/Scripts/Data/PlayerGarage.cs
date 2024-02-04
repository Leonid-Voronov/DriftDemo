using Services;
using System.Collections.Generic;
using System.Linq;
using Zenject;
using UnityEngine;

namespace Data
{
    public class PlayerGarage : ISavedProgress
    {
        private List<PurchasedCar> _purchasedCars = new List<PurchasedCar>();
        private Currency _currency;
        private ICarService _carService;

        public PlayerGarage(IPlayerDataService playerDataService, ICarService carService)
        {
            _currency = playerDataService.Currency;
            _carService = carService;
        }

        public List<PurchasedCar> PurchasedCars => _purchasedCars;
        public void LoadProgress(PlayerData playerData)
        {
            _purchasedCars = playerData.PurchasedCars;
        }

        public void UpdateProgress(PlayerData playerData)
        {
            playerData.PurchasedCars = _purchasedCars;
        }

        public bool BuyCar(CarName newCarName)
        {
            PurchasedCar newPurchasedCar = _carService.GetPurchasedCar(newCarName);

            if (_currency.SpendCash(newPurchasedCar.Cost))
            {
                _purchasedCars.Add(newPurchasedCar);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsCarPurchased(CarName carName) => _purchasedCars.Where(car => car.Name == carName).Count() != 0;
    }

    public enum CarName
    {
        Car1 = 0,
        Car2 = 1,
    }
}