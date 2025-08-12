using _GunGameBattle.Source.Player.Attack;
using _GunGameBattle.Source.Player.Equipment;
using _GunGameBattle.Source.Player.PickUp;
using _GunGameBattle.Source.Player.Shooting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using Zenject;

namespace _GunGameBattle.Source.Player.Input
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private MovementController _movementController;
        [SerializeField] private PlayerAttackController _attackController;
        [SerializeField] private PlayerPickUpController _playerPickUpController;
        
        private PlayerInputControls _playerInputControls;
        private PlayerEquipmentController _playerEquipmentController;
        
        [Inject]
        public void Initialize(PlayerInputControls playerInputControls, PlayerEquipmentController playerEquipmentController)
        {
            _playerInputControls = playerInputControls;
            _playerEquipmentController = playerEquipmentController;
        }

        private void Update()
        {
            CheckForMoveInput();
            CheckForEquipInput();
            CheckForFireInput();
            CheckForReloadInput();
            CheckForPickUpInput();
        }

        private void CheckForPickUpInput()
        {
            if (_playerInputControls.GamePlay.PickUp.WasPressedThisFrame())
                _playerPickUpController.TryPickup();
        }

        private void CheckForMoveInput()
        {
            var direction = _playerInputControls.GamePlay.Move.ReadValue<Vector2>();
            _movementController.Move(direction);
        }

        private void CheckForFireInput()
        {
            if (_playerInputControls.GamePlay.Shoot.WasPressedThisFrame()) 
                _attackController.PerformAttack();
        }

        private void CheckForReloadInput()
        {
            if (_playerInputControls.GamePlay.Reload.WasPressedThisFrame()) 
                _attackController.Reload();
        }

        private void CheckForEquipInput()
        {
            TrySelectItem(_playerInputControls.GamePlay.EquipFirstWeapon, 0);
            TrySelectItem(_playerInputControls.GamePlay.EquipSecondWeapon, 1);
            TrySelectItem(_playerInputControls.GamePlay.EquipThirdWeapon, 2);
        }

        private void TrySelectItem(InputAction action, int inventorySlotIndex)
        {
            if (action.WasPressedThisFrame())
                _playerEquipmentController.EquipItemFromInventory(inventorySlotIndex);
        }
    }
}