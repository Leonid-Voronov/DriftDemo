using Data;
using Services;
using UnityEngine;
using Zenject;
using Logic;
using Car;

namespace Infrastructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private DiContainer _diContainer;
        private PlayerGarage _playerGarage;
        private ICarPaintingService _carPaintingService;
        private ICarTuningService _carTuningService;

        private const string TimerPath = "Timer";

        [Inject]
        public GameplayFactory(DiContainer diContainer, IPlayerDataService playerDataService, ICarPaintingService carPaintingService, ICarTuningService carTuningService) 
        {
            _diContainer = diContainer;
            _playerGarage = playerDataService.PlayerGarage;
            _carPaintingService = carPaintingService;
            _carTuningService = carTuningService;
        }

        public GameObject CreateCar()
        {
            GameObject car = Create(_playerGarage.ActiveCar.PrefabPath);
            CarLinks carLinks = car.GetComponent<CarLinks>();
            _carPaintingService.PaintCar(carLinks);
            _carTuningService.TuneCar(carLinks, _playerGarage.ActiveCar);

            return car;
        }

        private GameObject Create(string path)
        {
            Object prefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(prefab);
        }

        public Timer CreateTimer() => Create(TimerPath).GetComponent<Timer>();
    }
}