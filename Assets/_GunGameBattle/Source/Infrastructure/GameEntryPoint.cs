using _GunGameBattle.Source.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Infrastructure
{
    public class GameEntryPoint : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        [Inject]
        private void Initialize(GameStateMachine gameStateMachine) => 
            _stateMachine = gameStateMachine;

        private void Start() => 
            _stateMachine.Enter<LoadProgressState>();
    }
}