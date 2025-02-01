using _GunGameBattle.Source.ScriptableObjects;
using UnityEngine;

namespace _GunGameBattle.Source.Weapon
{
    public class WeaponFactory : MonoBehaviour
    {
        [SerializeField] private GameObject _weaponPrefab;
        
        public IWeapon Create(WeaponConfig weaponConfig)
        {
            
        }
    }
}