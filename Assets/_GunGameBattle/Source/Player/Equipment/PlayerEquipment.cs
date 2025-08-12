using System;
using _GunGameBattle.Source.Items;

namespace _GunGameBattle.Source.Player.Equipment
{
    public sealed class PlayerEquipment
    {
        public event Action<Item> ItemEquipped;
        public event Action<Item> ItemUnequipped;
        
        public Item EquippedItem { get; private set; }

        public void TryEquipItem(Item item)
        {
            if (EquippedItem == null || EquippedItem.Id != item.Id)
                EquipItem(item);
        }

        private void EquipItem(Item item)
        {
            if (EquippedItem != null)
                UnequipItem();
            
            EquippedItem = item;
            ItemEquipped?.Invoke(item);
        }

        private void UnequipItem()
        {
            ItemUnequipped?.Invoke(EquippedItem);
            EquippedItem = null;
        }
    }
}