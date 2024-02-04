using Data;

namespace Services
{
    public interface ICarService
    {
        PurchasedCar GetPurchasedCar(CarName carName);
        PurchasedCar GetPurchasedCar(int dataIndex);
        int AllCarsCount { get; }
    }
}