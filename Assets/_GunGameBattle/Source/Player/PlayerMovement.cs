using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        
        private PlayerInputControls _playerInputControls;
        private bool _initialized;

        [Inject]
        public void Initialize(PlayerInputControls playerInputControls)
        {
            _playerInputControls = playerInputControls;

            _initialized = true;
        }

        private void Update()
        {
            if (!_initialized) 
                return;
            
            var direction = _playerInputControls.GamePlay.Move.ReadValue<Vector2>();
            Move(direction);
        }

        private void Move(Vector2 direction) => 
            gameObject.transform.transform.Translate(direction * (movementSpeed * Time.deltaTime));
    }
}