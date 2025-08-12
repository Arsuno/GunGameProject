using _GunGameBattle.Source.Player.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace _GunGameBattle.Source.UI
{
    public class KillsCountView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _label;
        
        private PlayerProgressWatcher _playerProgressWatcher;
        
        [Inject]
        private void Initialize(PlayerProgressWatcher playerProgressWatcher)
        {
            _playerProgressWatcher = playerProgressWatcher;
            
            _playerProgressWatcher.KillsCountChanged += OnKillsCountChanged;
        }

        private void OnKillsCountChanged() => 
            _label.text = $"Kills count: {_playerProgressWatcher.KillsCount}";
    }
}