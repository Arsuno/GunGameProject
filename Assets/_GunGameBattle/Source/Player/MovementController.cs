using UnityEngine;

namespace _GunGameBattle.Source.Player
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;

        public void Move(Vector2 direction) => 
            gameObject.transform.transform.Translate(direction * (_movementSpeed * Time.deltaTime));
    }
}