using _GunGameBattle.Source.Items.Configs;

namespace _GunGameBattle.Source.Items.WeaponTypes
{
    public class MeleeWeapon : Item
    {
        public int Damage { get; private set; }
        public float AttackCooldown { get; private set; }
        public float AttackRadius { get; private set; }
        
        protected override void InitializeSpecific(ItemConfig config)
        {
            MeleeWeaponConfig rangedWeaponConfig = (MeleeWeaponConfig)config;

            Damage = rangedWeaponConfig.Damage;
            AttackCooldown = rangedWeaponConfig.AttackCooldown;
            AttackRadius = rangedWeaponConfig.AttackRadius;
        }
    }
}