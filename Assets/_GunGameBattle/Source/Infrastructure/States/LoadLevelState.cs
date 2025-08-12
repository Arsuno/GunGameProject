namespace _GunGameBattle.Source.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        public const string GameplaySceneName = "Game";
        
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public LoadLevelState(SceneLoader sceneLoader, GameStateMachine stateMachine)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
        }
        
        public void Enter() => 
            _sceneLoader.Load("Game", OnLoaded);

        private void OnLoaded() => 
            _stateMachine.Enter<GameLoopState>();

        public void Exit() { }
    }
}