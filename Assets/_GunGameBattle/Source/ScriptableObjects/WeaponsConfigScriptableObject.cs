using UnityEngine;

namespace _GunGameBattle.Source.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configs/WeaponsConfig", fileName = "WeaponsConfig")]
    public class WeaponsConfigScriptableObject : ScriptableObject
    {
        public WeaponConfig[] Config;
    }
}