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
        [SerializeField] private GameDataConfig _gameDataConfig; //Изучить мб стоит сделать через Resources или Addressables
        
        private ItemFactory _itemFactory;
        private PlayerInventory _playerInventory;
        private PlayerEquipment _playerEquipment;
        private PlayerInputControls _playerInputControls;

        public override void InstallBindings()
        {
            CreateEntities();
            
            //ITEMS
            Container.Bind<ItemFactory>().FromInstance(_itemFactory).AsSingle();
            Container.Bind<ItemsData>().FromInstance(_gameDataConfig.Items).AsSingle();
            Container.Bind<IItemConfigProvider>().To<RandomItemConfigProvider>().AsSingle();
            
            //PLAYER DEPENDENCIES
            Container.Bind<PlayerInventory>().FromInstance(_playerInventory).AsSingle();
            Container.Bind<PlayerEquipment>().FromInstance(_playerEquipment).AsSingle();
            Container.Bind<PlayerInputControls>().FromInstance(_playerInputControls).AsSingle();
        }

        private void CreateEntities()
        {   
            _itemFactory = new ItemFactory();
            _playerInventory = new PlayerInventory(2);
            _playerEquipment = new PlayerEquipment();
            _playerInputControls = new PlayerInputControls();
            _playerInputControls.Enable();
        }
    }
}