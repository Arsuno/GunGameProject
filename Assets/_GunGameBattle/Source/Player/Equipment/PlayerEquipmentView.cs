using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using _GunGameBattle.Source.Player.Inventory;
using _GunGameBattle.Source.Player.Shooting;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _GunGameBattle.Source.Player.Equipment
{
    public class PlayerEquipmentView : MonoBehaviour
    {
        [FormerlySerializedAs("playerAimController")] [SerializeField] private PlayerWeaponAimController playerWeaponAimController; //TODO: Подумать как избавиться от такой прямой ссылки
        
        private PlayerEquipment _playerEquipment;
        private IItemConfigProvider _itemConfigProvider;

        [Inject]
        public void Initialize(PlayerEquipment playerEquipment, IItemConfigProvider itemConfigProvider)
        {
            _playerEquipment = playerEquipment;
            
            OnInitialize();
        }

        private void OnInitialize()
        {
            _playerEquipment.ItemEquipped += OnItemEquipped;
            _playerEquipment.ItemUnequipped += OnItemUnequipped;
        }

        private void OnDestroy()
        {
            _playerEquipment.ItemEquipped -= OnItemEquipped;
            _playerEquipment.ItemUnequipped -= OnItemUnequipped;
        }

        private void OnItemEquipped(Item item) //TODO Поработать над качеством кода (Стоит раздробить метод на несколько)
        {
            item.gameObject.SetActive(true);
            item.gameObject.transform.position = gameObject.transform.position;
            item.gameObject.transform.SetParent(transform);
            item.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
            
            playerWeaponAimController.Setup(item);
            
            Debug.Log("Item Equipped");
        }

        private void OnItemUnequipped(Item item)
        {
            item.gameObject.SetActive(false);
            
            playerWeaponAimController.Setup(null);
            Debug.Log("Item Unequipped");
        }
    }
}