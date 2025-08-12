using System;
using UnityEngine;

namespace _GunGameBattle.Source.Infrastructure.Data
{
    public class PlayerPrefsGameStorage : IGameStorage
    {
        private const string PlayerPrefsKey = "GamePrefsData";

        public void Load(Action<bool, string> onCompleted)
        {
            string data = PlayerPrefs.GetString(PlayerPrefsKey, "");
            Debug.Log("Data " + data);
            onCompleted?.Invoke(true, data);
        }

        public void Save(string data)
        {
            PlayerPrefs.SetString(PlayerPrefsKey, data);
            Debug.Log("Saved");
        }
    }
}