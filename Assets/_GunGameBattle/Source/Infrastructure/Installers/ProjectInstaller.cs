using _GunGameBattle.Source.Infrastructure.Data;
using _GunGameBattle.Source.Infrastructure.States;
using _GunGameBattle.Source.Player.Services;
using Zenject;

namespace _GunGameBattle.Source.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        private IGameStorage _storage;
        private SaveLoadSystem _saveLoadSystem;

        public override void InstallBindings()
        {
            Container.Bind<IGameStorage>().To<PlayerPrefsGameStorage>().AsSingle();
            Container.Bind<SaveLoadSystem>().AsSingle();
            Container.Bind<PlayerProgressWatcher>().AsSingle();
            Container.Bind<PlayerProgressDataConstructor>().AsSingle();
            Container.Bind<ICoroutineRunner>().FromComponentInHierarchy().AsSingle();
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
        }
    }
}