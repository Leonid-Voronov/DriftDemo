using Data;

namespace Services
{
    public interface IPlayerDataService
    {
        Currency Currency { get; }
        PlayerGarage PlayerGarage { get; }
    }
}