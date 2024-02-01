using Services.Input;
using Zenject;
using UnityEngine;

namespace Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallInfrastructureBindings();
            InstallInputBindings();
        }

        private void InstallInputBindings()
        {
            Container.Bind<PlayerInput>()
                .To<PlayerInput>()
                .AsSingle();

            Container.BindInterfacesTo<InputService>()
                .AsSingle();
        }

        private void InstallInfrastructureBindings()
        {
            Container.Bind<IGameplayFactory>()
                .To<GameplayFactory>()
                .AsSingle();
        }
    }
}

