using UnityEngine;

namespace _GunGameBattle.Source.Weapon
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        private int _damage;
        private int _ammoCount;
        
        private int _fireSpeed;
        private int _reloadSpeed;
        
        public void Shoot()
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            throw new System.NotImplementedException();
        }
    }
}