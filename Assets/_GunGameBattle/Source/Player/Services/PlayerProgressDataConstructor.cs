using _GunGameBattle.Source.Player.Data;
using Zenject;

namespace _GunGameBattle.Source.Player.Services
{
    public class PlayerProgressDataConstructor
    {
        private PlayerProgressWatcher _watcher;

        [Inject]
        private void Initialize(PlayerProgressWatcher watcher) => 
            _watcher = watcher;

        public PlayerProgress Build()
        {
            return new PlayerProgress()
            {
                KillsCount = _watcher.KillsCount,
            };
        }
    }
}