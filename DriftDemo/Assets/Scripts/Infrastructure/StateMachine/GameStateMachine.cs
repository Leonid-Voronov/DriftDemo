using Logic;
using Services;
using System;
using System.Collections.Generic;
using Zenject;

namespace Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        [Inject]
        public GameStateMachine(SceneLoader sceneLoader, IGameFactory gameFactory, ILocalStorageService localStorageService)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadProgressState)] = new LoadProgressState(this, localStorageService),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, gameFactory),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> payloadedState = ChangeState<TState>();
            payloadedState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState: class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}

