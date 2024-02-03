using Zenject;
using UnityEngine;
using Logic;
using Data;
using System.Collections.Generic;

namespace Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string CoroutineRunnerPath = "CoroutineRunner";
        private const string LoadingCurtainPath = "LoadingCurtain";
        private DiContainer _diContainer;

        private List<ISavedProgress> _progressObjects = new List<ISavedProgress>();

        [Inject]
        public GameFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
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

        public List<ISavedProgress> ProgressObjects => _progressObjects;
    }
}

