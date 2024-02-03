using Data;
using Infrastructure;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private const string ProgressKey = "Progress";

        private PlayerData _playerData;
        private IGameFactory _gameFactory;

        [Inject]
        public LocalStorageService(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Save()
        {
            _gameFactory.ProgressObjects.ForEach(obj => obj.UpdateProgress(_playerData));
            string json = JsonUtility.ToJson(_playerData);
            PlayerPrefs.SetString(ProgressKey, json);
        }

        public PlayerData Load()
        {
            _playerData = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString(ProgressKey)) ?? new PlayerData();
            _gameFactory.ProgressObjects.ForEach(obj => obj.LoadProgress(_playerData));
            return _playerData;
        }
    }
}

