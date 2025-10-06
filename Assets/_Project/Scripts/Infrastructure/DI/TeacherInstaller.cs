using _Project.Scripts.Application.UseCases.Player;
using _Project.Scripts.Application.UseCases.Teacher;
using _Project.Scripts.Application.Utilities;
using _Project.Scripts.Domain.Entities;
using _Project.Scripts.Infrastructure.Configs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Infrastructure.DI
{
    public class TeacherInstaller: MonoInstaller
    {
        [SerializeField] private Melody_SO _melody;
        [SerializeField] private TriggerEvent _triggerEvent;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<TriggerEvent<PlayerEntityContainer>>()
                .AsCached()
                .WithArguments(_triggerEvent);
            
            Container.Bind<Melody>().FromInstance(_melody.GetMelody()).AsSingle();
            Container.BindInterfacesTo<TeacherMediator>().AsCached();
        }
    }
}