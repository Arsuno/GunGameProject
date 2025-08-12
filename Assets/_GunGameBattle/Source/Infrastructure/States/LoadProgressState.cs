using _GunGameBattle.Source.Infrastructure.Data;

namespace _GunGameBattle.Source.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SaveLoadSystem _saveLoadSystem;

        public LoadProgressState(GameStateMachine stateMachine, SaveLoadSystem saveLoadSystem)
        {
            _stateMachine = stateMachine;
            _saveLoadSystem = saveLoadSystem;
        }

        public void Enter()
        {
            _saveLoadSystem.Load(OnDataLoaded); 
        }

        private void OnDataLoaded()
        {
            _stateMachine.Enter<LoadLevelState>();
        }

        public void Exit() { }
    }
}