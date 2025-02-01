using System;
using UnityEngine;

namespace _GunGameBattle.Source.ScriptableObjects
{
    [Serializable]
    public class WeaponConfig
    {
        [Header("Stats")]
        public int AmmoCount;
        public int Damage;
        public float ReloadSpeed;
        public float FireRate;

        [Header("Visual")] 
        public Sprite Sprite;
    }
}