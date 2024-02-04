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
        private PurchasedCar _activeCar;

        public PlayerGarage(IPlayerDataService playerDataService, ICarService carService)
        {
            _currency = playerDataService.Currency;
            _carService = carService;
            
        }
        public void LoadProgress(PlayerData playerData)
        {
            _purchasedCars = playerData.PurchasedCars;
            _activeCar = _purchasedCars.FirstOrDefault();
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

        public PurchasedCar ActiveCar => _activeCar;
        public void ChangeActiveCar(CarName carName) => _activeCar = _purchasedCars.Where(car => car.Name == carName).FirstOrDefault();
        public bool IsCarPurchased(CarName carName) => _purchasedCars.Where(car => car.Name == carName).Count() != 0;
        public PurchasedCar GetPurchasedCar(CarName carName) => _purchasedCars.Where(car => car.Name == carName).FirstOrDefault();
    }

    public enum CarName
    {
        Car1 = 0,
        Car2 = 1,
    }
}