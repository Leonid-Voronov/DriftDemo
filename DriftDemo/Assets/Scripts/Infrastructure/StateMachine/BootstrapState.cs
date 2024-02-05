using Services;

namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "InitialScene";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IAdsService _adsService;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, IAdsService adsService) 
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _adsService = adsService;
        }

        public void Enter()
        {
            _adsService.InitAds();
            _sceneLoader.Load(InitialSceneName, onLoaded: EnterLoadProgressState);
        }

        public void Exit()
        {
            
        }

        private void EnterLoadProgressState() => _gameStateMachine.Enter<LoadProgressState>();
    }
}

