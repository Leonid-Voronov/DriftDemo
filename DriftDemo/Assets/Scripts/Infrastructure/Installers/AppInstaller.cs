using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class AppInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
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
    }
}

