using Logic;
using UnityEngine;

namespace Infrastructure
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;
        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            _gameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain);
        }

        public GameStateMachine GameStateMachine => _gameStateMachine;
    }
}