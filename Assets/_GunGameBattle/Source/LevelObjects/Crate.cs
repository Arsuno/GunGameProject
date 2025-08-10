using System;
using _GunGameBattle.Source.Infrastructure.Factories;
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
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
                Destroy(this.gameObject);
        }

        private void OnDestroy() => 
            SpawnRandomItem();

        private void SpawnRandomItem()
        {
            var randomConfig = _itemConfigProvider.GetRandomItemConfig();
            var obj = _itemFactory.CreateAndInitialize(randomConfig);
            obj.transform.position = transform.position;
        }
    }
}