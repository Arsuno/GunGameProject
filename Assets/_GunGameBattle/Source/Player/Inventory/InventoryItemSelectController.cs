using System;
using _GunGameBattle.Source.Items;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class InventoryItemSelectController : MonoBehaviour
    {
        private PlayerInputControls _playerInputControls;
        private PlayerInventory _playerInventory;
        private PlayerEquipment _playerEquipment;

        [Inject]
        public void Initialize(PlayerInputControls playerInputControls, PlayerInventory playerInventory, PlayerEquipment playerEquipment)
        {
            _playerInputControls = playerInputControls;
            _playerInventory = playerInventory;
            _playerEquipment = playerEquipment;
        }
        
        private void Update()
        {
            TrySelectItem(_playerInputControls.GamePlay.EquipFirstWeapon, 0);
            TrySelectItem(_playerInputControls.GamePlay.EquipSecondWeapon, 1);
            TrySelectItem(_playerInputControls.GamePlay.EquipThirdWeapon, 2);
        }

        private void TrySelectItem(InputAction action, int itemIndex)
        {
            if (action.WasPressedThisFrame())
            {
                var item = _playerInventory.Items[itemIndex];
                
                if (item == null)
                {
                    Debug.Log($"Item with index {itemIndex} not found");
                    return;
                }

                if (_playerEquipment.EquippedItem == item)
                {
                    _playerEquipment.TryUnequipItem();
                    return;
                }
                    
                _playerEquipment.TryEquipItem(item);
            }
        }
    }
}