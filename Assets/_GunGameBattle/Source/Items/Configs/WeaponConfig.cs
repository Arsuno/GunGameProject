using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(menuName = "Configs/WeaponConfig", fileName = "WeaponConfig")]

    public class WeaponConfig : ItemConfig
    {
        public int Damage;
        public int AmmoCapacity;
        public float FireRate;
        public float ReloadTime;
        public BulletData BulletData;
    }
}