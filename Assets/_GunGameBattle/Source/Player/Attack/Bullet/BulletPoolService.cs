using System.Collections.Generic;
using _GunGameBattle.Source.Optimization;
using UnityEngine;

namespace _GunGameBattle.Source.Player.Attack.Bullet
{
    public class BulletPoolService : IBulletPoolService
    {
        private readonly Dictionary<Bullet, ObjectPool<Bullet>> _pools = new();

        public ObjectPool<Bullet> GetPool(Bullet prefab, int capacity)
        {
            if (prefab == null)
            {
                Debug.LogError("Bullet prefab is null");
                return null;
            }

            if (_pools.TryGetValue(prefab, out var pool))
                return pool;

            pool = new ObjectPool<Bullet>(capacity, prefab);
            _pools[prefab] = pool;
            return pool;
        }

        public void ClearAll()
        {
            foreach (var pool in _pools.Values)
            {
                if (pool.Objects != null && pool.Objects.Count > 0)
                {
                    foreach (var bullet in pool.Objects)
                    {
                        if (bullet != null)
                            Object.Destroy(bullet.gameObject);
                    }
                }
            }

            _pools.Clear();
        }
    }
}