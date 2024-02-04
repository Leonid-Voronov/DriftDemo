using Zenject;
using UnityEngine;
using Logic;
using Data;
using System.Collections.Generic;
using Services;

namespace Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string CoroutineRunnerPath = "CoroutineRunner";
        private const string LoadingCurtainPath = "LoadingCurtain";
        private DiContainer _diContainer;

        private List<ISavedProgress> _progressObjects = new List<ISavedProgress>();
        private ICarService _carService;

        [Inject]
        public GameFactory(DiContainer diContainer, ICarService carService)
        {
            _diContainer = diContainer;
            _carService = carService;
        }
        public Currency CreateCurrency()
        {
            Currency currency = new Currency();
            _progressObjects.Add(currency);
            return currency;
        }

        public ICoroutineRunner CreateCoroutineRunner() => Create(CoroutineRunnerPath).GetComponent<CoroutineRunner>();
        public LoadingCurtain CreateLoadingCurtain() => Create(LoadingCurtainPath).GetComponent<LoadingCurtain>();

        private GameObject Create(string path)
        {
            Object emptyPrefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(emptyPrefab);
        }

        public PlayerGarage CreatePlayerGarage(IPlayerDataService playerDataService)
        {
            PlayerGarage newGarage = new PlayerGarage(playerDataService, _carService);
            _progressObjects.Add(newGarage);
            return newGarage;
        }

        public List<ISavedProgress> ProgressObjects => _progressObjects;
    }
}

