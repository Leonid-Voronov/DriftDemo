using Services;
using System.Collections.Generic;

namespace Data
{
    [System.Serializable]
    public class PlayerData
    {
        public List<PurchasedCar> PurchasedCars { get; set; }

        public PlayerData(ICarService carService, bool calledFromNew = false)
        {
            if (!calledFromNew)
                return;

            PurchasedCars = new List<PurchasedCar>()
            {
                carService.GetPurchasedCar(CarName.Car1)
            };
        }
    }
}