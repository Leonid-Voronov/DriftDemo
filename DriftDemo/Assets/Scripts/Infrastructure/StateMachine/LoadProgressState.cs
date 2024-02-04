using Services;
using Zenject;

namespace Infrastructure
{
    public class LoadProgressState : IState
    {
        private GameStateMachine _gameStateMachine;
        private ILocalStorageService _localStorageService;

        public LoadProgressState(GameStateMachine gameStateMachine, ILocalStorageService localStorageService)
        {
            _gameStateMachine = gameStateMachine;
            _localStorageService = localStorageService;
        }
        
        public void Enter()
        {
            _localStorageService.Load();
            _gameStateMachine.Enter<LoadLevelState, string>("MainMenuScene");
        }

        public void Exit()
        {
           
        }
    }
}