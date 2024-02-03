namespace Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitialSceneName = "InitialScene";
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader) 
        {
            _gameStateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(InitialSceneName, onLoaded: EnterLoadProgressState);
        }

        public void Exit()
        {
            
        }

        private void EnterLoadProgressState() => _gameStateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {

        }
    }
}

