using UnityEngine;

namespace _GunGameBattle.Source.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Health _health;

        public Health Health => _health;
    }
}