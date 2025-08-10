using System;
using _GunGameBattle.Source.Items.Configs;
using UnityEngine;

namespace _GunGameBattle.Source.Items
{
    public abstract class Item : MonoBehaviour, IPickUpAble
    {
        public event Action<ItemConfig> OnInitialized;
        public int Id { get; private set; }

        public void Initialize(ItemConfig config)
        {
            Id = config.Id;
            InitializeSpecific(config);
            OnInitialized?.Invoke(config);
        }

        public Item PickUp()
        {
            gameObject.SetActive(false);
            return this;
        }

        protected abstract void InitializeSpecific(ItemConfig config);
    }
}