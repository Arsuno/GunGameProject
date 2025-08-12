using UnityEngine;

namespace _GunGameBattle.Source.Player.Attack.Strategies
{
    public interface IWeaponAttackStrategy
    {
        public void TryAttack(Vector3 targetPos);
    }
}