using _GunGameBattle.Source.Player.Services;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        
        private PlayerProgressWatcher _watcher;

        [Inject]
        private void Initialize(PlayerProgressWatcher watcher)
        {
            _watcher = watcher;
        }

        public Enemy Create(Vector3 position, Quaternion rotation)
        {
            Enemy enemy = Instantiate(_enemyPrefab, position, rotation);
            enemy.Health.Destroyed += _watcher.IncrementKills;
            
            return enemy;
        }
    }
}