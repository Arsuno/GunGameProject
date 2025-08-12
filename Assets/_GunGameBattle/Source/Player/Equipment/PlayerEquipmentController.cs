using _GunGameBattle.Source.Player.Inventory;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Equipment
{
    public class PlayerEquipmentController
    {
        private PlayerInventory _playerInventory;
        private PlayerEquipment _playerEquipment;

        [Inject]
        public void Initialize(PlayerInventory playerInventory, PlayerEquipment playerEquipment)
        {
            _playerInventory = playerInventory;
            _playerEquipment = playerEquipment;
        }
        
        public void EquipItemFromInventory(int itemIndex)
        {
            var item = _playerInventory.Items[itemIndex];
                
            if (item == null)
            {
                Debug.Log($"Item with index {itemIndex} not found");
                return;
            }
                    
            _playerEquipment.TryEquipItem(item);
        }
    }
}