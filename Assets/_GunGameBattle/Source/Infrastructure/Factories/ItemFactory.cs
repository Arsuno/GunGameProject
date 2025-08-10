using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using UnityEngine;

namespace _GunGameBattle.Source.Infrastructure.Factories
{
    public class ItemFactory
    {
        public GameObject CreateAndInitialize(ItemConfig config)
        {
            var item = Object.Instantiate(config.itemPrefab);
            
            var spriteRenderer = item.GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
            spriteRenderer.sprite = config.Sprite;
            
            item.GetComponent<Item>().Initialize(config);
            
            return item.gameObject;
        }
    }
}