using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Inventory
{
    public class PlayerEquipmentView : MonoBehaviour
    {
        [SerializeField] private PlayerAimController playerAimController; //TODO: Подумать как избавиться от такой прямой ссылки
        
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
            
            playerAimController.Setup(item);
            
            Debug.Log("Item Equipped");
        }

        private void OnItemUnequipped(Item item)
        {
            item.gameObject.SetActive(false);
            
            playerAimController.Setup(null);
            Debug.Log("Item Unequipped");
        }
    }
}