using Car;
using Data;

namespace Services
{
    public interface ICarTuningService
    {
        void TuneCar(CarLinks carLinks, PurchasedCar purchasedCar);
    }
}