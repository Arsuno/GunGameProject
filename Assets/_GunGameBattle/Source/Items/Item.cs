using _GunGameBattle.Source.Items.Configs;
using UnityEngine;

namespace _GunGameBattle.Source.Items
{
    public class Item : MonoBehaviour, IPickUpAble
    {
        public int Id;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Initialize(ItemConfig config)
        {
            _spriteRenderer.sprite = config.Sprite;
            Id = config.Id;
        }

        public Item PickUp()
        {
            Destroy(gameObject);
            return this;
        }
    }

    public interface IPickUpAble
    {
        public Item PickUp();
    }
}