using System;
using System.Collections.Generic;
using _GunGameBattle.Source.Infrastructure.Data;
using Zenject;

namespace _GunGameBattle.Source.Infrastructure.States
{
    public class GameStateMachine 
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        [Inject]
        public GameStateMachine(SceneLoader sceneLoader, SaveLoadSystem saveLoadSystem)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadProgressState)] = new LoadProgressState(this, saveLoadSystem),
                [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader, this),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            TState state = GetState<TState>(); 
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IState => 
            _states[typeof(TState)] as TState;
    }
}