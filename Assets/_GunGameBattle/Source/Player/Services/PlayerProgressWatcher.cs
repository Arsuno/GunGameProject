using System;
using _GunGameBattle.Source.Infrastructure.Data;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Player.Services
{
    public class PlayerProgressWatcher
    {
        public event Action KillsCountChanged;
        
        [Inject]
        private LazyInject<SaveLoadSystem> _saveLoadSystem;
        
        public int KillsCount { get; private set; }

        public void IncrementKills()
        {
            KillsCount++;
            _saveLoadSystem.Value.Save();
            KillsCountChanged?.Invoke();
        }
        
        public void SetKills(int value)
        {
            Debug.Log($"SetKills: {value}");
            KillsCount = Mathf.Max(0, value);
            KillsCountChanged?.Invoke();
        }
    }
}