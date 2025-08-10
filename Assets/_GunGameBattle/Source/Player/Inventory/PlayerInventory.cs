using System;
using System.Collections.Generic;
using _GunGameBattle.Source.Items;
using Unity.VisualScripting;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class PlayerInventory
    {
        public event Action<Item> ItemAdded;
        public event Action<Item> ItemRemoved;

        public readonly Item[] Items;

        public PlayerInventory(int capacity)
        {
            Items = new Item[capacity];
        }

        public void TryAddItem(Item item)
        {
            if (TryGetEmptySlotIndex(out int index))
            {
                Items[index] = item;
                ItemAdded?.Invoke(item);
            }
        }

        public bool HasEmptySlot() => 
            TryGetEmptySlotIndex(out _);

        private bool TryGetEmptySlotIndex(out int index)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    index = i;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        public void TryRemoveItem(int slotIndex)
        {
            if (slotIndex < 0 || slotIndex >= Items.Length)
                return;

            var item = Items[slotIndex];
            if (item == null)
                return;

            Items[slotIndex] = null;
            ItemRemoved?.Invoke(item);
        }

        public Item GetItem(int index) => Items[index];
    }
}