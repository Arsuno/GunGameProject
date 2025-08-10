using System.Collections;
using _GunGameBattle.Source.Items.Configs;
using _GunGameBattle.Source.Player.Shooting;
using UnityEngine;

namespace _GunGameBattle.Source.Items
{
    public class Weapon : Item
    {
        [SerializeField] private Transform _firePoint;
        
        private int _currentAmmoCount;
        private Coroutine _reloadCoroutine;
        private bool _reloadActive;

        public int Damage { get; private set; }
        public int AmmoCapacity { get; private set; }
        public float FireRate { get; private set; }
        public float ReloadTime { get; private set; }
        public Bullet BulletPrefab { get; private set; }
        public float BulletSpeed { get; private set; }
        public Transform FirePoint => _firePoint;

        protected override void InitializeSpecific(ItemConfig config)
        {
            WeaponConfig weaponConfig = (WeaponConfig)config;
            
            Damage = weaponConfig.Damage;
            AmmoCapacity = weaponConfig.AmmoCapacity;
            FireRate = weaponConfig.FireRate;
            ReloadTime = weaponConfig.ReloadTime;
            BulletPrefab = weaponConfig.BulletData.BulletPrefab;
            BulletSpeed = weaponConfig.BulletData.BulletSpeed;
            
            _currentAmmoCount = AmmoCapacity;
        }

        public bool TryShoot()
        {
            if (_currentAmmoCount > 0)
            {
                _currentAmmoCount -= 1;
                return true;
            }

            return false;
        }

        public void Reload()
        {
            if (_currentAmmoCount < AmmoCapacity && !_reloadActive)
                _reloadCoroutine = StartCoroutine(StartReloading());
        }

        private IEnumerator StartReloading()
        {
            _reloadActive = true;
            
            yield return new WaitForSeconds(ReloadTime);
            
            _currentAmmoCount = AmmoCapacity;
            _reloadActive = false;
            Debug.Log("Weapon reloaded");
        }
    }
}