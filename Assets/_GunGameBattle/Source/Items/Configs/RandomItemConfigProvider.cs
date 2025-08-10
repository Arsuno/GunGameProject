using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace _GunGameBattle.Source.Items.Configs
{
    public enum ItemType
    {
        Weapon,
        Heal,
    }
    
    public class RandomItemConfigProvider : IItemConfigProvider
    {
        private readonly List<ItemConfig> Items;

        private ItemsData _itemsData;

        public RandomItemConfigProvider(ItemsData itemsData) => 
            _itemsData = itemsData;

        public ItemConfig GetRandomItemConfig()
        {
            var itemType = GetRandomItemType();
            return GetConfigByItemType(itemType);
        }

        private ItemConfig GetConfigByItemType(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                {
                    var array = _itemsData.WeaponsConfigs;
                    return array[Random.Range(0, array.Count)];
                }


                case ItemType.Heal:
                {
                    var array = _itemsData.HealingItemsConfigs;
                    return array[Random.Range(0, array.Count)];
                }
                
                default:
                    throw new Exception("Unknown item type");
            }
        }

        private ItemType GetRandomItemType()
        {
            var values = Enum.GetValues(typeof(ItemType));
            var randomIndex = Random.Range(0, values.Length);
            
            return (ItemType)values.GetValue(randomIndex);
        }
    }
}