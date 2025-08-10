using System;
using UnityEngine;

namespace _GunGameBattle.Source
{
    public class Health : MonoBehaviour
    {
        public event Action ValueChanged;
        public event Action Destroyed;

        [SerializeField] private int _maxValue;

        public float CurrentValue { get; private set;}
        public float MaxValue => _maxValue;

        private void Awake() => 
            CurrentValue = _maxValue;

        public void Heal(int amount)
        {
            if (CurrentValue + amount <= _maxValue)
                CurrentValue += amount;
            else
                CurrentValue = _maxValue;

            ValueChanged?.Invoke();
        }

        public void TakeDamage(int amount)
        {
            Debug.Log($"Damage taken: {amount}");
            
            if (CurrentValue - amount > 0)
            {
                CurrentValue -= amount;
            }
            else
            {
                CurrentValue = 0;
                Die();
            }

            ValueChanged?.Invoke();
        }

        private void Die()
        {
            Destroy(gameObject);
            Destroyed?.Invoke();
        }
    }
}