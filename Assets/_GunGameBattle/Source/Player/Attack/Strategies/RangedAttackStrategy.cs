using System.Collections;
using _GunGameBattle.Source.Infrastructure;
using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.WeaponTypes;
using _GunGameBattle.Source.Optimization;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Attack.Strategies
{
    public sealed class RangedAttackStrategy : IWeaponAttackStrategy, IReloadable
    {
        private readonly RangedWeapon _weapon;
        private readonly ObjectPool<Bullet.Bullet> _pool;
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly int _maxAmmoCount;
        
        private int _currentAmmoCount;
        private bool _isReloading;

        public RangedAttackStrategy(ICoroutineRunner coroutineRunner, RangedWeapon weapon, ObjectPool<Bullet.Bullet> pool)
        {
            _weapon = weapon;
            _pool = pool;
            
            _coroutineRunner = coroutineRunner;
            _maxAmmoCount = weapon.AmmoCapacity;
            _currentAmmoCount = _maxAmmoCount;
        }

        public void TryAttack(Vector3 targetPos)
        {
            if (_isReloading && _currentAmmoCount <= 0) 
                return;

            CreateAndSetupBullet(targetPos);
        }

        public void TryReload()
        {
            if (_currentAmmoCount < _maxAmmoCount && !_isReloading)
                _coroutineRunner.StartCoroutine(StartReloading());
        }

        private IEnumerator StartReloading()
        {
            _isReloading = true;
            
            yield return new WaitForSeconds(_weapon.ReloadTime);
            
            _currentAmmoCount = _weapon.AmmoCapacity;
            _isReloading = false;
            Debug.Log("Weapon reloaded");
        }

        private void CreateAndSetupBullet(Vector3 targetPos)
        {
            var bullet = _pool.Get();
            bullet.gameObject.transform.position = _weapon.FirePoint.position;

            var direction = (targetPos - _weapon.FirePoint.position).normalized;

            bullet.HitTarget += OnBulletHitTarget;
            bullet.Initialize(_weapon.Damage, direction, _weapon.BulletSpeed);
        }

        private void OnBulletHitTarget(Bullet.Bullet bullet)
        {
            bullet.HitTarget -= OnBulletHitTarget;
            _pool.Release(bullet);
        }
    }
}