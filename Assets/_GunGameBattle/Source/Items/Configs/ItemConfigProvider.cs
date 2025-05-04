using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace _GunGameBattle.Source.Items.Configs
{
    public class ItemConfigProvider : IItemConfigProvider
    {
        private readonly Dictionary<int, ItemConfig> ItemConfigs; //Проблема в возможном дубляже конфигов
        private readonly List<ItemConfig> Items;
        
        public ItemConfigProvider(ItemsData itemsData)
        {
            Items = itemsData.ItemsConfigs;
            ItemConfigs = new Dictionary<int, ItemConfig>();

            foreach (var item in Items)
                ItemConfigs.Add(item.Id, item);
        }

        public ItemConfig GetItemConfigById(int id)
        {
            if (ItemConfigs.TryGetValue(id, out ItemConfig itemConfig))
                return itemConfig;
            
            throw new KeyNotFoundException();
        }

        public ItemConfig GetRandomItemConfig()
        {
            if (ItemConfigs.Count <= 0)
                throw new ArgumentOutOfRangeException();
            
            var randomIndex = Random.Range(0, Items.Count);
            return Items[randomIndex];
        }
    }
}