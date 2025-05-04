using _GunGameBattle.Source.Items;
using UnityEngine;
using UnityEngine.UI;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class InventorySlotView : MonoBehaviour
    {
        [SerializeField] private Image _itemIconImage;
        
        [SerializeField] private Sprite _defaultSprite;
        
        public Item Item { get; private set; }
        
        public bool Empty => 
            Item == null;

        public void AssignItem(Item item)
        {
            Item = item;
            
            _itemIconImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        }

        public void Clear()
        {
            Item = null;
            _itemIconImage.sprite = _defaultSprite;
        }
    }
}