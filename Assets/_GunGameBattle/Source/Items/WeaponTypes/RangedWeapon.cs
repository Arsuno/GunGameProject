using _GunGameBattle.Source.Items.Configs;
using _GunGameBattle.Source.Player.Attack.Bullet;
using UnityEngine;

namespace _GunGameBattle.Source.Items.WeaponTypes
{
    public class RangedWeapon : Item
    {
        [SerializeField] private Transform _firePoint;
        
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
            RangedWeaponConfig rangedWeaponConfig = (RangedWeaponConfig)config;
            
            Damage = rangedWeaponConfig.Damage;
            AmmoCapacity = rangedWeaponConfig.AmmoCapacity;
            FireRate = rangedWeaponConfig.FireRate;
            ReloadTime = rangedWeaponConfig.ReloadTime;
            BulletPrefab = rangedWeaponConfig.BulletData.BulletPrefab;
            BulletSpeed = rangedWeaponConfig.BulletData.BulletSpeed;
        }
    }
}