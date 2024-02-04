using Data;

namespace Services
{
    public interface ICarService
    {
        PurchasedCar GetPurchasedCar(CarName carName);
        int AllCarsCount { get; }
    }
}