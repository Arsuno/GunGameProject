using _GunGameBattle.Source.Items;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class PlayerAimController : MonoBehaviour
    {
        private Transform _equippedItemTransform;
        private SpriteRenderer _equippedItemSpriteRenderer;
        private bool _initialized;

        public void Setup(Item item) //TODO: Стоит подумать над решением получше
        {
            if (item == null)
            {
                _initialized = false;
                return;
            }
            
            _equippedItemTransform = item.transform;
            _equippedItemSpriteRenderer = item.GetComponent<SpriteRenderer>();
            _initialized = true;
        }
        
        private void Update()
        {
            if (!_initialized)
                return;
            
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = _equippedItemTransform.position.z;

            Vector3 direction = (mouseWorldPos - _equippedItemTransform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _equippedItemTransform.rotation = Quaternion.Euler(0f, 0f, angle);

            bool shouldFlip = angle > 90f || angle < -90f;
            _equippedItemSpriteRenderer.flipY = shouldFlip;
        }
    }
}