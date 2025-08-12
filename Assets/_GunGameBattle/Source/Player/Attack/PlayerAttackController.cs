using _GunGameBattle.Source.Infrastructure;
using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Optimization;
using _GunGameBattle.Source.Player.Attack.Strategies;
using _GunGameBattle.Source.Player.Equipment;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Attack
{
    public sealed class PlayerAttackController : MonoBehaviour, ICoroutineRunner
    {
        private PlayerEquipment _playerEquipment;
        
        private ObjectPool<Bullet.Bullet> _bulletPool;
        private IWeaponAttackStrategy _currentAttackStrategy;
        private IAttackStrategyFactory _strategyFactory;
        
        [Inject]
        private void Initialize(PlayerEquipment playerEquipment, IAttackStrategyFactory strategyFactory)
        {
            _playerEquipment = playerEquipment;
            _strategyFactory = strategyFactory;
            
            OnInitialized();
        }

        private void OnInitialized() =>
            _playerEquipment.ItemEquipped += OnItemEquipped;

        private void OnDestroy() =>
            _playerEquipment.ItemEquipped -= OnItemEquipped;

        public void PerformAttack()
        {
            var targetPos = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Input.mousePosition.x,
                UnityEngine.Input.mousePosition.y, 0));
            
            _currentAttackStrategy?.TryAttack(targetPos);
        }

        public void Reload()
        {
            if (_currentAttackStrategy is IReloadable reloadable)
                reloadable.TryReload();
        }
        
        private void OnItemEquipped(Item item) => 
            _currentAttackStrategy = _strategyFactory.Create(item);
    }
}