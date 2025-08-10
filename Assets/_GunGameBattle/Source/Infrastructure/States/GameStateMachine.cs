using System;
using System.Collections.Generic;

namespace _GunGameBattle.Source.Infrastructure.States
{
    public class GameStateMachine 
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(LoadProgressState)] = new LoadProgressState(this),
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