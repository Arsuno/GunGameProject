using System.Collections.Generic;
using UnityEngine;

namespace _GunGameBattle.Source.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        public List<Enemy> SpawnedEnemies { get; private set; } = new();

        private void Start() =>
            SpawnedEnemies = SpawnEnemies();

        private List<Enemy> SpawnEnemies()
        {
            if (SpawnedEnemies.Count > 0)
                SpawnedEnemies.Clear();

            List<Enemy> enemies = new List<Enemy>();

            foreach (var spawnPoint in _spawnPoints)
            {
                Enemy enemy = _enemyFactory.Create(spawnPoint.position, Quaternion.identity);
                enemies.Add(enemy);
            }

            return enemies;
        }
    }
}