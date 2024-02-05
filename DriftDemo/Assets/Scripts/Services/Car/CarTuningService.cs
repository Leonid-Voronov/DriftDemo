using Car;
using Data;

namespace Services
{
    public class CarTuningService : ICarTuningService
    {
        public void TuneCar(CarLinks carLinks, PurchasedCar purchasedCar)
        {
            if (carLinks.SpoilerObject != null)
            {
                carLinks.SpoilerObject.SetActive(purchasedCar.WithSpoiler);
            }
        }
    }
}