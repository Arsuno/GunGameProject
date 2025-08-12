using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.LevelObjects
{
    public class Crate : MonoBehaviour
    {
        [SerializeField] private Health _health;
        
        private IItemConfigProvider _itemConfigProvider;
        private ItemFactory _itemFactory;

        [Inject]
        public void Initialize(IItemConfigProvider itemConfigProvider, ItemFactory itemFactory)
        {
            _itemConfigProvider = itemConfigProvider;
            _itemFactory = itemFactory;
            
            _health.Destroyed += OnCrateDestroyed;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
                _health.TakeDamage(100);
        }

        private void OnDestroy() =>
            _health.Destroyed -= OnCrateDestroyed;

        private void OnCrateDestroyed() => 
            SpawnRandomItem();

        private void SpawnRandomItem()
        {
            var randomConfig = _itemConfigProvider.GetRandomItemConfig();
            var obj = _itemFactory.CreateAndInitialize(randomConfig);
            obj.transform.position = transform.position;
        }
    }
}