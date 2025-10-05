using _Game.Scripts.Core.DI;
using _Project.Scripts.Infrastructure.Input;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class InputServiceInstaller : SubInstaller
    {  
        public override void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesAndSelfTo<InputService>()
                .AsSingle();
        }
    }
}