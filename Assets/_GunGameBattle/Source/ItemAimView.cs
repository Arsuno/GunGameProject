using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Player.Inventory;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source
{
    public class ItemAimView : MonoBehaviour
    {
        [SerializeField] private Transform _itemTransform;
        
        private PlayerInventory _playerInventory;
        private bool _itemEquipped = true;

        [Inject]
        public void Initialize(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        private void Update()
        {
            if (!_itemEquipped)
                return;
            
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = _itemTransform.position.z;

            Vector3 direction = (mouseWorldPos - _itemTransform.position).normalized;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _itemTransform.rotation = Quaternion.Euler(0f, 0f, angle);

            bool shouldFlip = angle > 90f || angle < -90f;
            //_itemTransform = shouldFlip;
        }

        private void OnItemEquipped(Item item) => 
            _itemEquipped = true;

        private void OnItemUnequipped(Item item) => 
            _itemEquipped = false;
    }

    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] private Transform _equipmentPointTransform;

        public void Equip(Item item)
        {
            
        }
    }
}