using _GunGameBattle.Source.Infrastructure;
using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.WeaponTypes;
using _GunGameBattle.Source.Player.Attack.Bullet;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Attack.Strategies
{
    public class AttackStrategyFactory : IAttackStrategyFactory
    {
        private readonly IBulletPoolService _bulletPoolService;
        private readonly ICoroutineRunner _coroutineRunner;

        [Inject]
        public AttackStrategyFactory(IBulletPoolService bulletPoolService, ICoroutineRunner coroutineRunner)
        {
            _bulletPoolService = bulletPoolService;
            _coroutineRunner = coroutineRunner;
        }

        public IWeaponAttackStrategy Create(Item item)
        {
            if (item is RangedWeapon rangedWeapon)
            {
                var capacity = Mathf.Max(8, rangedWeapon.AmmoCapacity * 2);
                var pool = _bulletPoolService.GetPool(rangedWeapon.BulletPrefab, capacity);
                
                return new RangedAttackStrategy(_coroutineRunner, rangedWeapon, pool);
            }

            if (item is MeleeWeapon meleeWeapon)
                return new MeleeAttackStrategy(meleeWeapon);

            Debug.LogWarning($"No attack strategy for item type: {item?.GetType().Name ?? "null"}");
            return null;
        }
    }
}