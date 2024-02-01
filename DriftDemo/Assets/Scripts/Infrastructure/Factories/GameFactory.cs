using Zenject;
using UnityEngine;
using Logic;

namespace Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private const string CoroutineRunnerPath = "CoroutineRunner";
        private const string LoadingCurtainPath = "LoadingCurtain";
        private DiContainer _diContainer;
        [Inject]
        public GameFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public ICoroutineRunner CreateCoroutineRunner() => Create(CoroutineRunnerPath).GetComponent<CoroutineRunner>();
        public LoadingCurtain CreateLoadingCurtain() => Create(LoadingCurtainPath).GetComponent<LoadingCurtain>();

        private GameObject Create(string path)
        {
            Object emptyPrefab = Resources.Load(path);
            return _diContainer.InstantiatePrefab(emptyPrefab);
        }
    }
}

