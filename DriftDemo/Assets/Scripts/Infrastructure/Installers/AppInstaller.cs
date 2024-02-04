using Data;
using Logic;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
            InstallProgressBindings();
            InstallLogicBindings();
            InstallServiceBindings();
            InstallExtensionBindgings();
        }

        private void InstallInfrastructureBindings()
        {
            Container.Bind<Game>()
                .To<Game>()
                .AsSingle();

            Container.Bind<GameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();

            Container.Bind<SceneLoader>()
                .To<SceneLoader>()
                .AsSingle();

            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();
        }

        private void InstallProgressBindings()
        {
            Container.Bind<ILocalStorageService>()
                .To<LocalStorageService>()
                .AsSingle();

            Container.Bind<IPlayerDataService>()
                .To<PlayerDataService>()
                .AsSingle().NonLazy();
        }

        private void InstallLogicBindings()
        {
            Container.BindInterfacesAndSelfTo<SaveTrigger>()
                .AsSingle();
        }

        private void InstallServiceBindings()
        {
            Container.Bind<ICarService>()
                .To<CarService>()
                .AsSingle();

            Container.Bind<IAppExitService>()
                .To<AppExitService>()
                .AsSingle();
        }

        private void InstallExtensionBindgings()
        {
            Container.Bind<IEnumStringConvertService>()
                .To<EnumStringConvertService>()
                .AsSingle();
        }
    }
}

