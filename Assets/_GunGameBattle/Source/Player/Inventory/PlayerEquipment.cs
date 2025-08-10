using System;
using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class PlayerEquipment
    {
        public event Action<Item> ItemEquipped;
        public event Action<Item> ItemUnequipped;
        
        public Item EquippedItem { get; private set; }

        public void TryEquipItem(Item item)
        {
            if (EquippedItem == null || EquippedItem.Id != item.Id)
                EquipItem(item);
        }

        public void TryUnequipItem()
        {
            if (EquippedItem != null)
                UnequipItem();
        }

        private void EquipItem(Item item)
        {
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