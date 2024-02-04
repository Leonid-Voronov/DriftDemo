using Data;
using Infrastructure;
using UnityEngine;
using Zenject;
using Newtonsoft.Json;

namespace Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private const string ProgressKey = "Progress";

        private PlayerData _playerData;
        private IGameFactory _gameFactory;
        private ICarService _carService;

        [Inject]
        public LocalStorageService(IGameFactory gameFactory, ICarService carService)
        {
            _gameFactory = gameFactory;
            _carService = carService;
        }

        public void Save()
        {
            _gameFactory.ProgressObjects.ForEach(obj => obj.UpdateProgress(_playerData));
            string json = JsonConvert.SerializeObject(_playerData, Formatting.Indented);
            json = json.Replace(".0", "");
            PlayerPrefs.SetString(ProgressKey, json);
        }

        public PlayerData Load()
        {
            _playerData = JsonConvert.DeserializeObject<PlayerData>(PlayerPrefs.GetString(ProgressKey)) ?? new PlayerData(_carService, calledFromNew: true);
            _gameFactory.ProgressObjects.ForEach(obj => obj.LoadProgress(_playerData));
            return _playerData;
        }
    }
}

