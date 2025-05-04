using _GunGameBattle.Source.Infrastructure.Factories;
using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using _GunGameBattle.Source.Player.Inventory;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Infrastructure.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private Item _itemPrefab;
        [SerializeField] private ItemsData _itemsData;
        
        
        public override void InstallBindings()
        {
            var itemFactory = new ItemFactory(_itemPrefab);
            var playerInventory = new PlayerInventory();
            
            Container.Bind<ItemFactory>().FromInstance(itemFactory).AsSingle();
            Container.Bind<ItemsData>().FromInstance(_itemsData).AsSingle();
            Container.Bind<IItemConfigProvider>().To<ItemConfigProvider>().AsSingle();
            Container.Bind<PlayerInventory>().FromInstance(playerInventory).AsSingle();
        }
    }
}