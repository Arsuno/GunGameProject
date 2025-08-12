using UnityEngine;

namespace _GunGameBattle.Source.Items.Configs
{
    [CreateAssetMenu(menuName = "Configs/MeleeWeaponConfig", fileName = "MeleeWeaponConfig")]
    public class MeleeWeaponConfig : ItemConfig
    {
        public int Damage;
        public float AttackCooldown;
        public float AttackRadius;
    }
}