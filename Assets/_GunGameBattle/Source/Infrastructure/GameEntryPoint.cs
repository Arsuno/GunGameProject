using _GunGameBattle.Source.Infrastructure.States;
using UnityEngine;

namespace _GunGameBattle.Source.Infrastructure
{
    public class GameEntryPoint : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new GameStateMachine(new SceneLoader(this));
            _stateMachine.Enter<LoadLevelState>();
        }
    }

}