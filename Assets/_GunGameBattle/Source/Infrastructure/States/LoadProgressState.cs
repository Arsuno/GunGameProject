namespace _GunGameBattle.Source.Infrastructure.States
{
    public class LoadProgressState : IState //Грузим сохранения
    {
        private readonly GameStateMachine _stateMachine;
        
        public LoadProgressState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            //Грузим сохранения
            OnLoaded();
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<LoadLevelState>();
        }

        public void Exit() { }
    }
}