using Data;

namespace Services
{
    public interface ILocalStorageService
    {
        PlayerData Load();
        void Save();
    }
}