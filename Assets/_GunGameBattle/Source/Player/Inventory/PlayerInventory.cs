using System;
using System.Collections.Generic;
using _GunGameBattle.Source.Items;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class PlayerInventory
    {
        public event Action<Item> ItemAdded;
        public event Action<Item> ItemRemoved;

        private Dictionary<int, Item> _items = new();

        public void TryAddItem(Item item)
        {
            if (ItemExists(item))
            {
                Debug.Log("Item already exists");
                return;
            }

            AddItem(item);
        }

        private bool ItemExists(Item item) => 
            _items.ContainsKey(item.Id);

        private void AddItem(Item item)
        {
            _items.Add(item.Id, item);
            ItemAdded?.Invoke(item);
        }

        public void TryRemoveItem(Item item)
        {
            if (!_items.ContainsKey(item.Id))
                return;
            
            RemoveItem(item);
        }

        private void RemoveItem(Item item)
        {
            _items.Remove(item.Id);
            ItemRemoved?.Invoke(item);
        }
    }
}