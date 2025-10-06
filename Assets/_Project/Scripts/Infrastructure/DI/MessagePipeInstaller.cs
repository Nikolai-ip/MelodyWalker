using _Project.Scripts.Application.DTOs;
using _Project.Scripts.Application.UseCases.Player;
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
            Container.BindMessageBroker<PlayerWorldState>(new MessagePipeOptions());

        }
    }
}