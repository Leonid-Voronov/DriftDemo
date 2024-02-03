using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private DiContainer _diContainer;
        private IGameFactory _factory;

        private const string CarPath = "Cars/DefaultCar";
        [Inject]
        public GameplayFactory(DiContainer diContainer, IGameFactory factory) 
        {
            _diContainer = diContainer;
            _factory = factory;
        }

        public GameObject CreateCar() => Create(CarPath);

        private GameObject Create(string path)
        {
            Object emptyPrefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(emptyPrefab);
        }
    }
}