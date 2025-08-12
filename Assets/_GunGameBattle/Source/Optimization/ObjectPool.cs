using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _GunGameBattle.Source.Optimization
{
    public class ObjectPool<T> where T : Component
    {
        public Queue<T> Objects;
        private T _prefab;

        public ObjectPool(int capacity, T prefab)
        {
            Objects = new Queue<T>(capacity);
            
            _prefab = prefab;
        }
        
        public T Get()
        {
            if (Objects.Count > 0)
                return Objects.Dequeue();
            else
                return CreateNewObject();
        }

        private T CreateNewObject() => Object.Instantiate(_prefab);

        public void Release(T component) => 
            Objects.Enqueue(component);
    }
}