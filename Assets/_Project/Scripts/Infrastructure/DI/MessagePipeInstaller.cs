using _Project.Scripts.Application.DTOs;
using MessagePipe;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class MessagePipeInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindMessagePipe();
            Container.BindMessageBroker<NewMelodyLearned>(new MessagePipeOptions());
        }
    }
}