using UnityEngine;

namespace _GunGameBattle.Source.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;
        
        private PlayerInputControls _playerInputControls;

        private void Awake()
        {
            _playerInputControls = new PlayerInputControls();
            _playerInputControls.Enable();
        }

        private void Update()
        {
            var direction = _playerInputControls.GamePlay.Move.ReadValue<Vector2>();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            gameObject.transform.transform.Translate(direction * (movementSpeed * Time.deltaTime));
        }
        
    }
}