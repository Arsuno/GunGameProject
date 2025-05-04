using System;
using _GunGameBattle.Source.BaseInterfaces;
using _GunGameBattle.Source.Infrastructure.Factories;
using _GunGameBattle.Source.Items.Configs;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.LevelObjects
{
    public class Crate : MonoBehaviour, IDamageable
    {
        [SerializeField] private int _health;
        
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
                Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            if (_health - damage >= 0)
            {
                _health -= damage;
            }
            else
            {
                var randomConfig = _itemConfigProvider.GetRandomItemConfig();
                var obj = _itemFactory.CreateAndInitialize(randomConfig);
                obj.transform.position = transform.position;       
            }
        }
    }
}