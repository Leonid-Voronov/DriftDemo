using Data;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private DiContainer _diContainer;
        private PlayerGarage _playerGarage;
        [Inject]
        public GameplayFactory(DiContainer diContainer, IPlayerDataService playerDataService) 
        {
            _diContainer = diContainer;
            _playerGarage = playerDataService.PlayerGarage;
        }

        public GameObject CreateCar() => Create(_playerGarage.ActiveCar.PrefabPath);

        private GameObject Create(string path)
        {
            Object emptyPrefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(emptyPrefab);
        }
    }
}