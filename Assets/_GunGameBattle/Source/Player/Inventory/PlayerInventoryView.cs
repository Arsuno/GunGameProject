using System;
using _GunGameBattle.Source.Items;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class PlayerInventoryView : MonoBehaviour
    {
        [SerializeField] private InventorySlotView[] _slots;

        private PlayerInventory _playerInventory;

        [Inject]
        public void Initialize(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
            
            _playerInventory.ItemAdded += OnItemAdded;
            _playerInventory.ItemRemoved += OnItemRemoved;
        }

        private void OnDestroy()
        {
            _playerInventory.ItemAdded -= OnItemAdded;
            _playerInventory.ItemRemoved -= OnItemRemoved;
        }

        private void OnItemAdded(Item item)
        {
            Debug.Log("VIEW - OnItemAdded");
            var slot = CheckForEmptySlots(item);
            
            slot.AssignItem(item);
        }

        private void OnItemRemoved(Item item)
        {
            var slot = FindSlotByItemId(item.Id);
            
            slot?.Clear();
        }

        private InventorySlotView CheckForEmptySlots(Item item)
        {
            foreach (var slot in _slots)
            {
                if (slot.Empty)
                    return slot;
            }
            
            throw new NotImplementedException("No empty slots");
        }

        private InventorySlotView FindSlotByItemId(int itemId)
        {
            foreach (var slot in _slots)
            {
                if (slot.Item.Id == itemId)
                    return slot;
            }
            
            throw new NotImplementedException("Slot with that ID not found");
        }
    }
}