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
        private StartPoint _startPoint;

        private const string TimerPath = "Timer";

        [Inject]
        public GameplayFactory(DiContainer diContainer, IPlayerDataService playerDataService, ICarPaintingService carPaintingService, ICarTuningService carTuningService, StartPoint startPoint) 
        {
            _diContainer = diContainer;
            _playerGarage = playerDataService.PlayerGarage;
            _carPaintingService = carPaintingService;
            _carTuningService = carTuningService;
            _startPoint = startPoint;
        }

        public GameObject CreateCar()
        {
            GameObject car = CreateAt(_playerGarage.ActiveCar.PrefabPath, _startPoint.transform.position);
            CarLinks carLinks = car.GetComponent<CarLinks>();
            _carPaintingService.PaintCar(carLinks);
            _carTuningService.TuneCar(carLinks, _playerGarage.ActiveCar);

            return car;
        }

        private GameObject CreateAt(string path, Vector3 at)
        {
            Object prefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(prefab, at, Quaternion.identity, null);
        }

        private GameObject Create(string path)
        {
            Object prefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(prefab);
        }

        public Timer CreateTimer() => Create(TimerPath).GetComponent<Timer>();
    }
}