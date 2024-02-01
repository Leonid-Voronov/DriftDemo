using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameplayFactory : IGameplayFactory
    {
        private DiContainer _diContainer;

        private const string CarPath = "Cars/DefaultCar";
        [Inject]
        public GameplayFactory(DiContainer diContainer) 
        {
            _diContainer = diContainer;
        }

        public GameObject CreateCar() => Create(CarPath);

        private GameObject Create(string path)
        {
            Object emptyPrefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(emptyPrefab);
        }
    }
}