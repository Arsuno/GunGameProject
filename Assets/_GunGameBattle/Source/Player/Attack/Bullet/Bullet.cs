using System;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Attack.Bullet
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
    public class Bullet : MonoBehaviour
    {
        public event Action<Bullet> HitTarget; 
        
        private int _damage;
        private Rigidbody2D _rigidbody;

        private void Awake() => 
            _rigidbody = GetComponent<Rigidbody2D>();

        public void Initialize(int damage, Vector2 direction, float speed)
        {
            _damage = damage;
            
            _rigidbody.linearVelocity = direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Health health))
            {
                health.TakeDamage(_damage);
                gameObject.SetActive(false);
                HitTarget?.Invoke(this);
            }
        }
    }
}