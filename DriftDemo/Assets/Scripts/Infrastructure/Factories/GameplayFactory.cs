using Car;
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
        private ICarPaintingService _carPaintingService;
        
        [Inject]
        public GameplayFactory(DiContainer diContainer, IPlayerDataService playerDataService, ICarPaintingService carPaintingService) 
        {
            _diContainer = diContainer;
            _playerGarage = playerDataService.PlayerGarage;
            _carPaintingService = carPaintingService;
        }

        public GameObject CreateCar()
        {
            GameObject car = Create(_playerGarage.ActiveCar.PrefabPath);
            _carPaintingService.PaintCar(car);
            return car;
        }

        private GameObject Create(string path)
        {
            Object emptyPrefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(emptyPrefab);
        }
    }
}