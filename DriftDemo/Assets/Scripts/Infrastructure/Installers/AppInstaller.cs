using Car;
using Data;
using Logic;
using Services;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class AppInstaller : MonoInstaller
    {
        [SerializeField] private CarsMaterialsHolderSO _carsMaterialsHolderSO;

        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
            InstallProgressBindings();
            InstallLogicBindings();
            InstallServiceBindings();
            InstallExtensionBindgings();
            InstallDataBindings();
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

            Container.Bind<ICarPaintingService>()
                .To<CarPaintingService>()
                .AsSingle();

            Container.Bind<IDropdownInitializationService>()
                .To<DropdownInitializationService>()
                .AsSingle();

            Container.Bind<ICarTuningService>()
                .To<CarTuningService>()
                .AsSingle();

            Container.BindInterfacesTo<AdsService>()
                .AsSingle();
        }

        private void InstallExtensionBindgings()
        {
            Container.Bind<IConvertService>()
                .To<ConvertService>()
                .AsSingle();
        }

        private void InstallDataBindings()
        {
            Container.Bind<CarsMaterialsHolderSO>()
                .FromInstance(_carsMaterialsHolderSO)
                .AsSingle();
        }
    }
}

