using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(menuName = "Configs/RangedWeaponConfig", fileName = "RangedWeaponConfig")]

    public class RangedWeaponConfig : ItemConfig
    {
        public int Damage;
        public int AmmoCapacity;
        public float FireRate;
        public float ReloadTime;
        public BulletData BulletData;
    }
}