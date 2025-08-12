using _GunGameBattle.Source.Enemy;
using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.Configs;
using _GunGameBattle.Source.Player.Attack.Bullet;
using _GunGameBattle.Source.Player.Attack.Strategies;
using _GunGameBattle.Source.Player.Equipment;
using _GunGameBattle.Source.Player.Inventory;
using _GunGameBattle.Source.Player.Services;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Infrastructure.Installers
{
    public class GameplaySceneInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawner _enemySpawner; 
        [SerializeField] private GameDataConfig _gameDataConfig; //Изучить мб стоит сделать через Resources или Addressables
        
        private ItemFactory _itemFactory;
        private PlayerInventory _playerInventory;
        private PlayerEquipment _playerEquipment;
        private PlayerInputControls _playerInputControls;

        public override void InstallBindings()
        {
            //CONFIGS
            Container.BindInstance(_gameDataConfig.Items).AsSingle();

            //ITEMS
            Container.Bind<IItemConfigProvider>().To<RandomItemConfigProvider>().AsSingle();
            Container.Bind<ItemFactory>().AsSingle();

            //PLAYER
            Container.Bind<PlayerInventory>().AsSingle().WithArguments(2);
            Container.Bind<PlayerEquipment>().AsSingle();
            Container.Bind<PlayerEquipmentController>().AsSingle();
            Container.Bind<PlayerInputControls>()
                .FromMethod(_ =>
                {
                    var c = new PlayerInputControls();
                    c.Enable();
                    return c;
                })
                .AsSingle()
                .NonLazy();

            //SERVICES
            Container.Bind<IBulletPoolService>().To<BulletPoolService>().AsSingle();
            Container.Bind<IAttackStrategyFactory>().To<AttackStrategyFactory>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromComponentInHierarchy().AsSingle();

            //PLAYER PROGRESS
            
            //ENEMY
            Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle();
        }
    }
}