using System;
using _GunGameBattle.Source.Player.Data;
using _GunGameBattle.Source.Player.Services;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.Infrastructure.Data
{
    public class SaveLoadSystem
    {
        private const string PlayerDataKey = "PlayerData";

        private IGameStorage _storage;
        private PlayerProgress _playerProgress;
        private PlayerProgressDataConstructor _playerProgressDataConstructor;
        private PlayerProgressWatcher _watcher;

        [Inject]
        public SaveLoadSystem(IGameStorage storage, PlayerProgressDataConstructor playerProgressDataConstructor, PlayerProgressWatcher watcher)
        {
            _storage = storage;
            _playerProgressDataConstructor = playerProgressDataConstructor;
            _watcher = watcher;
        }

        public void Save()
        {
            _playerProgress = _playerProgressDataConstructor.Build();
            
#if UNITY_EDITOR
            string json = JsonUtility.ToJson(_playerProgress, true);
#else
            string json = JsonUtility.ToJson(_playerProgress);
#endif
            
            _storage.Save(json);
        }

        public void Load(Action onCompleted = null)
        {
            _storage.Load((ok, json) =>
            {
                if (ok && !string.IsNullOrEmpty(json))
                {
                    var data = SafeFromJson(json, new PlayerProgress());
                    _watcher.SetKills(data.KillsCount);
                }
                else
                {
                    _watcher.SetKills(0);
                    Debug.Log("Сохранений не найдено");
                }

                onCompleted?.Invoke();
            });
        }

        private static T SafeFromJson<T>(string json, T fallback)
        {
            try { return JsonUtility.FromJson<T>(json); }
            catch (Exception e)
            {
                Debug.LogWarning($"[SaveLoad] bad JSON, fallback. {e.Message}");
                return fallback;
            }
        }
    }
}