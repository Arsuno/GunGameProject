using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Player.Inventory;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.PickUp
{
    public class PlayerPickUpController : MonoBehaviour
    {
        [SerializeField] private PlayerPickupZone _pickupZone;

        private PlayerInventory _playerInventory;

        [Inject]
        public void Initialize(PlayerInventory playerInventory)
        {
            _playerInventory = playerInventory;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && _playerInventory.HasEmptySlot())
                TryPickup();
        }

        private void TryPickup()
        {
            if (_pickupZone.Items.Count > 0)
            {
                IPickUpAble nearestItem = _pickupZone.GetNearestItem();

                if (nearestItem == null)
                    return;

                Debug.Log("Item picked up");
                var item = nearestItem.PickUp();
                _playerInventory.TryAddItem(item);
            }
        }
    }
}