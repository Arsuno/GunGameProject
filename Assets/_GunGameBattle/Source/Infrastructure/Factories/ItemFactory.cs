using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using UnityEngine;

namespace _GunGameBattle.Source.Infrastructure.Factories
{
    public class ItemFactory
    {
        private Item _itemPrefab;
        
        public ItemFactory(Item itemPrefab)
        {
            _itemPrefab = itemPrefab;
        }
        
        public GameObject CreateAndInitialize(ItemConfig config)
        {
            var item = Object.Instantiate(_itemPrefab);
            item.Initialize(config);

            return item.gameObject;
        }
    }
}