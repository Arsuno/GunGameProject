using _GunGameBattle.Source.Items;
using _GunGameBattle.Source.Items.WeaponTypes;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Attack.Strategies    
{
    public sealed class MeleeAttackStrategy : IWeaponAttackStrategy
    {
        private readonly MeleeWeapon _weapon;
        private readonly Collider2D[] _hits;
        
        private float _nextReadyTime;

        public MeleeAttackStrategy(MeleeWeapon weapon, int bufferSize = 8)
        {
            _weapon = weapon;
            _hits = new Collider2D[bufferSize];
        }

        public void TryAttack(Vector3 _)
        {
            if (Time.time < _nextReadyTime)
                return;
            
            Vector2 center = _weapon.transform.position;
            float radius = _weapon.AttackRadius;

            int hitsCount = Physics2D.OverlapCircleNonAlloc(center, radius, _hits);
            
            for (int i = 0; i < hitsCount; i++)
            {
                var col = _hits[i];
                if (!col) continue;

                if (col.transform.root == _weapon.transform.root)
                    continue;

                if (col.TryGetComponent(out Health health)) 
                    health.TakeDamage(_weapon.Damage);
            }

            _nextReadyTime = Time.time + _weapon.AttackCooldown;
        }
    }
}