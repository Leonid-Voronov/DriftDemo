using Logic;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;

        [Inject]
        public Game(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public GameStateMachine GameStateMachine => _gameStateMachine;
    }
}