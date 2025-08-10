using _GunGameBattle.Source.Items.Configs;
using UnityEngine;

namespace _GunGameBattle.Source.Items
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Item _item;
        
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private void OnEnable()
        {
            _item.OnInitialized += OnItemInitialized;
        }

        private void OnDisable()
        {
            _item.OnInitialized -= OnItemInitialized;
        }

        private void OnItemInitialized(ItemConfig config)
        {
            _spriteRenderer.sprite = config.Sprite;
        }
    }
}